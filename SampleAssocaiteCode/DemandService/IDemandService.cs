using SampleAssocaiteCode.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAssocaiteCode.DemandService
{
    public interface IDemandService
    {
        Task<IQueryable<Demand>> Get();
        Task<bool> Post(Demand demand);
    }
}
