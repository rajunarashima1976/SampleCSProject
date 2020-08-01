using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAssocaiteCode.DemandService;
using SampleAssocaiteCode.EntityModel;

namespace SampleAssocaiteCode.Controllers
{
    [Route("api/demand")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly IDemandService _demandService;
        private readonly IMapper _mapper;
        public DemandController(IDemandService demandService, IMapper mapper)
        {
            _demandService = demandService;
            //_mapper = mapper;
            _mapper = mapper;
            int x = 100;
            int y = 200;
            int z = 300;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _demandService.Get();
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Demand demand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _demandService.Post(demand);
            return Ok(response);
        }
    }
}
