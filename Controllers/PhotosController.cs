using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using TouristApi.Models;
using TouristApi.Services.PhotoServices;

namespace TouristApi.Controllers
{
    [Route("photos")]
    public class PhotosController : ControllerBase
    {

        private readonly IPhotoServices _repository;

        public PhotosController(IPhotoServices repository)
        {
            _repository = repository;
        }



        [HttpPost]
        [Route("add-Photo")]
        public async Task<ActionResult> AddPlace([FromForm] Photo photo)
        {
            if (photo == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(photo);
            return Ok(photo);
        }


        [HttpGet]
        [Route("get-photos")]
        public async Task<ActionResult> GetPhotos([FromQuery] int page)
        {

            return Ok(await _repository.GetItems(page));
        }

        [HttpGet]
        [Route("get-Videos")]
        public async Task<ActionResult> GetVideos([FromQuery] int page)
        {

            return Ok(await _repository.GetVideos(page));
        }


        [HttpGet]
        [Route("get-photos-by-placeId")]
        public async Task<ActionResult> GetPhotosByPlaceId([FromQuery] int page, [FromQuery] int placeId)
        {

            return Ok(await _repository.GetPhotosByPlaceId(placeId, page));
        }



        [HttpPost]
        [Route("delete-Photo")]
        public async Task<ActionResult> DeletePhoto([FromForm] int couponId)
        {
            Photo photo = await _repository.DeleteAsync(couponId);

            if (photo == null)
            {

                return NotFound();
            }



            return Ok(photo);
        }


    }
}