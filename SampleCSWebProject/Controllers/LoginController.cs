using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
//using SampleAssocaiteCode.Comman;
//using SampleAssocaiteCode.Common;
using SampleCSWebProject.ModelsDTO;
using SampleCSWebProject.Models;
using SampleCSWebProject.Comman;

namespace SampleCSWebProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        private AppSettings _settings;
        public LoginController(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return await Task.FromResult(View());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(User user)
        {
            var loginResultData = new UserRolesDTO();
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    //string baseUri = _settings.ApiUrl + "/" + Constants.Token + "/";
                    string baseUri = "https://localhost:44326/token/";
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsJsonAsync(baseUri, user);
                    var result = response.Content.ReadAsStringAsync().Result;
                    loginResultData = JsonConvert.DeserializeObject<UserRolesDTO>(result);

                }
            }
            if (loginResultData != null && loginResultData.Token != null)
            {
                HttpContext.Session.SetString("JWTToken", loginResultData.Token);
                HttpContext.Session.SetString("UserName", loginResultData.Username);
                HttpContext.Session.SetString("RoleName", loginResultData.RoleName);
                return await Task.FromResult(RedirectToAction("Index", "Dashboard"));
            }
            else
            {
                ViewBag.message = "Invalid username and password!";
                return await Task.FromResult(View());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("JWTToken");
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("RoleName");
            HttpContext.Session.Clear();

            return await Task.FromResult(RedirectToAction("Index", "Login"));
        }

    }
}
