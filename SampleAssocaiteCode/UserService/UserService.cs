using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleAssocaiteCode.Common;
using SampleAssocaiteCode.EntityModel;
using SampleAssocaiteCode.Models;

namespace SampleAssocaiteCode.UserService
{
    public class UserService:IUserService
    {
        private readonly TalmateDBContext _talmateDbContext;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings,TalmateDBContext talmateDbContext)
        {
            _appSettings = appSettings.Value;
            _talmateDbContext = talmateDbContext;
        }

        public async Task<UserRolesDTO> Authenticate(string username, string password)
        {

            var user = (from u in _talmateDbContext.Users
                        join ur in _talmateDbContext.UserRoles on u.Id equals ur.UserId
                        join r in _talmateDbContext.Roles on ur.RoleId equals r.Id
                        where u.Username == username && u.Password == password
                        select new UserRolesDTO()
                        {
                            Id = u.Id,
                            Username = u.Username,
                            RoleName = r.Name
                        }).FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return await Task.FromResult(user);
        }


        public async Task<IQueryable<User>> GetAll()
        {
            return await Task.FromResult(_talmateDbContext.Users.AsQueryable());
        }

        public async Task<User> GetById(int id)
        {
            var user = _talmateDbContext.Users.AsQueryable().FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(user);
        }
    }
}
