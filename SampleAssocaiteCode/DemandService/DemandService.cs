using SampleAssocaiteCode.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAssocaiteCode.DemandService
{
    public class DemandService:IDemandService
    {
        private readonly TalmateDBContext _talmateDbContext;
        public DemandService(TalmateDBContext talmateDbContext)
        {
            _talmateDbContext = talmateDbContext;
        }

        public async Task<IQueryable<Demand>> Get()
        {
            var demand = _talmateDbContext.Demands.AsQueryable().OrderBy(c => c.PrimarySkills);
            return await Task.FromResult(demand);


        }

        public async Task<bool> Post(Demand demand)
        {
            if (demand != null)
            {
                _talmateDbContext.Demands.Add(demand);
                var result = _talmateDbContext.SaveChanges();
                if (result > 0)
                    return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }


    }
}
