using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TouristApi.Dtos;
using TouristApi.Models;
using TouristApi.Services;

namespace TouristApi.Controllers
{
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
        public async Task<ActionResult> GitCitiesByCountryId([FromQuery] int countryId,[FromQuery] int page)
        {

            return Ok(await _repository.GitCitiesByCountryId(countryId,page));
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

            if (city == null)
            {

                return NotFound();
            }



            return Ok(city);
        }


             [HttpPost]
        [Route("update-city")]
        public async Task<ActionResult> UpdateCountry([FromForm] UpdateCity update ,[FromForm] int Id)
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
   
    }}