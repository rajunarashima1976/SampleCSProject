using Microsoft.EntityFrameworkCore;
using SampleAssocaiteCode.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAssocaiteCode
{
    public class TalmateDBContext:DbContext
    {
        public TalmateDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Demand> Demands { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<ResourceDetail> ResourceDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
    }
}
