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
    }
}
