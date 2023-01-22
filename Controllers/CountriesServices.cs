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
    [Route("countries")]
    public class CountriesController : ControllerBase
    {
        
   private readonly ICountriesService _repository;
        private IMapper _mapper;

        public CountriesController(ICountriesService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


         [HttpPost]
        [Route("add-country")]
        public async Task<ActionResult> AddCountry([FromForm] Country Country)
        {
            if (Country == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(Country);

            return Ok(Country);
        }


        [HttpGet]
        [Route("get-countries")]
        public async Task<ActionResult> GetCountries([FromQuery] int page)
        {

            return Ok(await _repository.GetItems(page));
        }
   
       [HttpGet]
        [Route("get-all-countries")]
        public async Task<ActionResult> GetAllCountries()
        {

            return Ok(await _repository.GitAllCountries());
        }

      [HttpGet]
        [Route("get-country-byId")]
        public async Task<ActionResult> GetCountryById([FromQuery] int couponId)
        {

            return Ok(await _repository.GitById(couponId));
        }




          [HttpGet] 
        [Route("get-countries-by-cont-Id")]
        public async Task<ActionResult> GitCountriesByContinentId([FromQuery] int continentId)
        {

            return Ok(await _repository.GitCountriesByContinentId(continentId));
        }




       [HttpPost]
        [Route("delete-country")]
        public async Task<ActionResult> DeleteCountry([FromForm] int couponId)
        {
            Country country = await _repository.DeleteAsync(couponId);

            if (country == null)
            {

                return NotFound();
            }



            return Ok(country);
        }

           [HttpPost]
        [Route("update-country")]
        public async Task<ActionResult> UpdateCountry([FromForm] UpdateCountry update ,[FromForm] int Id)
        {
             Country country = await _repository.GitById(Id);
            if (country == null)
            {
                return NotFound();
            }
           
           
            _mapper.Map(update, country);

            // _repository.UpdateCart(cart);
            _repository.SaveChanges();

            return Ok(country);
        }
   
    }
}