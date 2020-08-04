using SampleAssocaiteCode.EntityModel;
using SampleAssocaiteCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAssocaiteCode.UserService
{
    public interface IUserService
    {
        Task<UserRolesDTO> Authenticate(string username, string password);
        Task<IQueryable<User>> GetAll();
        Task<User> GetById(int id);
    }
}
