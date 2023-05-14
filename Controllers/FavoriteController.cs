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
    [Route("Favorite")]
    public class FavoriteController : ControllerBase
    {

        private readonly IFavoriteService _repository;
        private IMapper _mapper;

        public FavoriteController(IFavoriteService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add-favorite")]
        public async Task<ActionResult> AddFavorite([FromForm] Favorite city)
        {
            if (city == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(city);

            return Ok(city);
        }


        [HttpGet]
        [Route("get-favorites")]
        public async Task<ActionResult> GetFavorites([FromQuery] string ids)
        {

            return Ok(await _repository.GetFavorites(ids));
        }

        [HttpGet]
        [Route("get-favorite-byId")]
        public async Task<ActionResult> GetFavoriteById([FromQuery] int couponId)
        {

            return Ok(await _repository.GitById(couponId));
        }

        

        


        [HttpPost]
        [Route("delete-favorite")]
        public async Task<ActionResult> DeleteFavorite([FromForm] int favoriteId)
        {
            Favorite favorite = await _repository.DeleteAsync(favoriteId);

            if (favorite == null)
            {

                return NotFound();
            }



            return Ok(favorite);
        }

    }
}