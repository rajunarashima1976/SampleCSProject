using Microsoft.EntityFrameworkCore;
using SampleAssocaiteCode.EntityModel;
using System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCSWebProject.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        DbSet<Demand> demandrequirement { get; set; }
    }
}
