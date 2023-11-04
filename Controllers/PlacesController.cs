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
using TouristApi.Services.PhotoServices;

namespace TouristApi.Controllers
{
    [Route("places")]
    public class PlacesController : ControllerBase
    {

        private readonly IPlacesService _repository;
        private readonly IPhotoServices _repositoryPhotos;
        private IMapper _mapper;

        public PlacesController(IPlacesService repository, IMapper mapper, IPhotoServices repositoryPhotos)
        {
            _repository = repository;
            _repositoryPhotos = repositoryPhotos;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add-place")]
        public async Task<ActionResult> AddPlace([FromForm] Place city)
        {
            if (city == null)
            {
                return NotFound();
            }

            Place place = await _repository.Add(city);
            Photo photo = new Photo
            {
                PlaceId = place.Id,
                image = place.Image,
                CityId = place.CityId,

            };
            await _repositoryPhotos.AddAsync(photo);

            return Ok(city);
        }


        [HttpGet]
        [Route("get-places")]
        public async Task<ActionResult> GetPlaces([FromForm] int page)
        {

            return Ok(await _repository.GetItems(page));
        }
        [HttpGet]
        [Route("get-placeDetails")]
        public async Task<ActionResult> GetPlaceDetails([FromQuery] int placeId)
        {

            return Ok(await _repository.GetPlaceDetails(placeId));
        }



        [HttpGet]
        [Route("get-all-places")]
        public async Task<ActionResult> GetAllPlaces()
        {

            return Ok(await _repository.GetAll());
        }


        [HttpGet]
        [Route("get-places-details")]
        public async Task<ActionResult> GetPlacesDetails([FromQuery] int cityId,[FromQuery] int index)
        {

            return Ok(await _repository.GetPlaceDetailsList(cityId,index));
        }


        [HttpGet]
        [Route("get-place-byId")]
        public async Task<ActionResult> GetPlaceById([FromQuery] int cityId)
        {

            return Ok(await _repository.GitById(cityId));
        }




        [HttpGet]
        [Route("git-places-byCountryId")]
        public async Task<ActionResult> GitPlacesByCountryId([FromQuery] int countryId, [FromQuery] int page)
        {

            return Ok(await _repository.GitPlacesByCountryId(countryId, page));
        }

        [HttpGet]
        [Route("git-places-byCountryId-admin")]
        public async Task<ActionResult> GitPlacesByCountryIdAdmin([FromQuery] int countryId)
        {

            return Ok(await _repository.GitPlacesByCountryIdAdmin(countryId));
        }

        [HttpGet]
        [Route("git-places-by-city-Id")]
        public async Task<ActionResult> GitPlacesByCityId([FromQuery] int cityId, [FromQuery] int page)
        {

            return Ok(await _repository.GitPlacesByCityId(cityId, page));
        }


  [HttpGet]
        [Route("git-places-most-popular")]
        public async Task<ActionResult> GitPlacesMostPopular()
        {

            return Ok(await _repository.GetMostPopularPlaces());
        }


        [HttpGet]
        [Route("git-places-by-city-Id-admin")]
        public async Task<ActionResult> GitPlacesByCityIdAdmin([FromQuery] int cityId)
        {

            return Ok(await _repository.GitPlacesByCityIdAdmin(cityId));
        }


        [HttpPost]
        [Route("delete-place")]
        public async Task<ActionResult> DeletePlace([FromForm] int couponId)
        {
            City place = await _repository.DeleteAsync(couponId);

            if (place == null)
            {

                return NotFound();
            }



            return Ok(place);
        }


        [HttpPost]
        [Route("update-place")]
        public async Task<ActionResult> UpdatePlace([FromForm] UpdatePlace update, [FromForm] int Id)
        {
            Place country = await _repository.GitById(Id);
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