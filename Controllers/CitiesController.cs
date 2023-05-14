using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TouristApi.Dtos;
using TouristApi.Models;
using TouristApi.Services;
using TouristApi.ViewModel;

namespace TouristApi.Controllers
{

    //  dotnet commends

// dotnet publish --configuration Release
// migrations dotnet
// dotnet ef migrations add InitialCreate
 // update database 
// dotnet ef database update
// create
// dotnet new webapi -n name
    [Route("cities")]
    public class CitiesController : ControllerBase
    {

        private readonly ICitiesService _repository;
        private IMapper _mapper;

        public CitiesController(ICitiesService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add-city")]
        public async Task<ActionResult> AddCity([FromForm] City City)
        {
            if (City == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(City);

            return Ok(City);
        }


        [HttpGet]
        [Route("get-cities")]
        public async Task<ActionResult> GetCities([FromForm] int page)
        {

            return Ok(await _repository.GetItems(page));
        }


        [HttpGet]
        [Route("get-all-cities")]
        public async Task<ActionResult> GetAllCities()
        {

            return Ok(await _repository.GetAllItems());
        }
        [HttpGet]
        [Route("get-city-byId")]
        public async Task<ActionResult> GetCityById([FromQuery] int couponId)
        {

            return Ok(await _repository.GitById(couponId));
        }




        [HttpGet]
        [Route("git-cities-byCountryId")]
        public async Task<ActionResult> GitCitiesByCountryId([FromQuery] int countryId)
        {

            return Ok(await _repository.GitCitiesByCountryId(countryId));
        }

        [HttpGet]
        [Route("search_city")]
        public async Task<ActionResult> SearchCities([FromQuery] string textSearch)
        {

            return Ok(await _repository.SearchCity(textSearch));
        }


        [HttpGet]
        [Route("git-cities-byCountryId-admin")]
        public async Task<ActionResult> GitCitiesByCountryIdAdmin([FromQuery] int continentId)
        {

            return Ok(await _repository.GitCitiesByCountryIdAdmin(continentId));
        }


        [HttpPost]
        [Route("delete-city")]
        public async Task<ActionResult> DeleteCity([FromForm] int couponId)
        {
            City city = await _repository.DeleteAsync(couponId);

          



            return Ok(city);
        }


        [HttpPost]
        [Route("update-city")]
        public async Task<ActionResult> UpdateCountry([FromForm] UpdateCity update, [FromForm] int Id)
        {
            City city = await _repository.GitById(Id);
            if (city == null)
            {
                return NotFound();
            }


            _mapper.Map(update, city);

            // _repository.UpdateCart(cart);
            _repository.SaveChanges();

            return Ok(city);
        }



        [HttpGet]
        [Route("get-city-details")]
        public async Task<ActionResult> GitCityDetails([FromQuery] int cityId)
        {


            return Ok(await _repository.GetCityDetails(cityId));
        }


        [HttpGet]
        [Route("git-weather")]
        public async Task<IActionResult> City([FromQuery] string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?lang=ar&q={city}&appid=f99e4be1f07b9b39845b0055fd9bc2e6&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    return Ok(new
                    {
                        Temp = rawWeather!.Main!.Temp,
                        Summary = string.Join(",", rawWeather.Weather!.Select(x => x.Description)),
                        City = rawWeather.Name,
                        icon = string.Join(",", rawWeather.Weather!.Select(x => x.icon)),
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }

    }
}