using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SampleCSWebProject.Models;
using SampleCSWebProject.ModelsDTO;
using SampleCSWebProject.Comman;
using Microsoft.AspNetCore.Http;

namespace SampleCSWebProject.Controllers
{
    public class DemandController : Controller
    {
        private readonly IMapper _mapper;
        private SampleAssocaiteCode.Common.AppSettings _settings;
        private IMapper object1;
        private IOptions<AppSettings> object2;

        public DemandController(IMapper mapper, IOptions<SampleAssocaiteCode.Common.AppSettings> settings)
        {
            _mapper = mapper;
            _settings = settings.Value;
        }

        public DemandController(IMapper object1, IOptions<AppSettings> object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Demand demand)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    //string baseUri = _settings.ApiUrl + "/" + Constants.API + "/" + Constants.Demand + "/";
                    string baseUri = "https://localhost:44326/api/demand/";
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsJsonAsync(baseUri, demand);
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result == "")
                        status = false;
                    else
                        status = JsonConvert.DeserializeObject<bool>(result);
                }
                if (status)
                {
                    ViewBag.message = "Demand Created Successfully!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.message = "Unable to create Demand!";
                }
            }

            return await Task.FromResult(View());
        }


        [HttpGet]
        public async Task<IActionResult> ViewDemand()
        {
            var demand = new List<Demand>();
            using (var client = new HttpClient())
            {
                //string baseUri = _settings.ApiUrl + "/" + Constants.API + "/" + Constants.Demand + "/";
                string baseUri = "https://localhost:44326/api/demand/";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JWTToken"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(baseUri);
                var result = response.Content.ReadAsStringAsync().Result;
                demand = JsonConvert.DeserializeObject<List<Demand>>(result);
            }
            return await Task.FromResult(View(demand));
        }

    }
}
