using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCSWebProject.Mappings
{
    public class DemandProfile:Profile
    {
        public DemandProfile()
        {
            CreateMap<Demand, DemandDTO>();
        }
    }
}
