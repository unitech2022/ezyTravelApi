using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TouristApi.Models;
using TouristApi.Services;

namespace TouristApi.Controllers
{
    [Route("Continent")]
    public class ContinentsController : ControllerBase
    {
          private readonly IContinentsService _repository;
        private IMapper _mapper;

        public ContinentsController(IContinentsService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         [HttpPost]
        [Route("add-continent")]
        public async Task<ActionResult> AddContinent([FromForm] Continent Continent)
        {
            if (Continent == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(Continent);

            return Ok(Continent);
        }


        [HttpGet]
        [Route("get-Continents")]
        public async Task<ActionResult> GetContinents([FromQuery] int page)
        {

            return Ok(await _repository.GetItems(page));
        }
     [HttpGet]
        [Route("get-Continents-all")]
        public async Task<ActionResult> GetContinentsAll()
        {

            return Ok(await _repository.GetItemsAll());
        }
        [HttpGet]
        [Route("get-continent-byId")]
        public async Task<ActionResult> GetCouponById([FromQuery] int couponId)
        {

            return Ok(await _repository.GitById(couponId));
        }



          [HttpPost]
        [Route("delete-continent")]
        public async Task<ActionResult> DeleteCoupon([FromForm] int couponId)
        {
            Continent continent = await _repository.DeleteAsync(couponId);

            if (continent == null)
            {

                return NotFound();
            }



            return Ok(continent);
        }
   

     
         [HttpPost]
        [Route("update-continent")]
        public async Task<ActionResult> UpdateContinent([FromForm] UpdateContinent update ,[FromForm] int Id)
        {
             Continent continent = await _repository.GitById(Id);
            if (continent == null)
            {
                return NotFound();
            }
           
           
            _mapper.Map(update, continent);

            // _repository.UpdateCart(cart);
            _repository.SaveChanges();

            return Ok(continent);
        }


    }


}