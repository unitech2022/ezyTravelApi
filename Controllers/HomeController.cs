using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TouristApi.Services.HomeService;

namespace TouristApi.Controllers
{
    [Route("home")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeServices _repository;
   

        public HomeController(IHomeServices repository)
        {
            _repository = repository;
          
        }


        [HttpGet]
        [Route("get-home-dash")]
        public async Task<ActionResult> GetHomeDash()
        {

            return Ok(await _repository.GetHomeDashboard());
        }


        [HttpGet]
        [Route("get-home")]
        public async Task<ActionResult> GetHome()
        {

            return Ok(await _repository.GetHome());
        }

    }
}