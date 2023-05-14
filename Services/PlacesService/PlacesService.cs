using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Data;
using AutoMapper;
using X.PagedList;
using TouristApi.Models.BaseEntity;
using TouristApi.Models;
using Microsoft.EntityFrameworkCore;
using TouristApi.ViewModel;

namespace TouristApi.Services
{
    public class PlacesService : IPlacesService
    {

        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public PlacesService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic place)
        {

            await _context.Places!.AddAsync(place);
            await _context.SaveChangesAsync();
            return place;

        }
        public async Task<dynamic> Add(Place place)
        {
            City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == place.CityId);
            place.CountryId = city!.CountryId;
            await _context.Places!.AddAsync(place);
            await _context.SaveChangesAsync();
            return place;

        }



        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Place? place = await _context.Places!.FirstOrDefaultAsync(x => x.Id == typeId);



            if (place != null)
            {
                _context.Places!.Remove(place);

                await _context.SaveChangesAsync();
            }

            return place!;

        }

        public async Task<dynamic> GetItems(int page)
        {
            List<Place> places = await _context.Places!.ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(places.Count() / pageResults);

            var items = await places
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }

        public async Task<dynamic> GetPlaceDetails(int placeId)
        {
            List<string> photos = new List<string>();
            List<string> videos = new List<string>();

            Place? place = await _context.Places!.FirstOrDefaultAsync(t => t.Id == placeId);
            City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == place!.CityId);

            Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == place!.CountryId);

            List<Photo> allPhotos = await _context.Photos!.Where(t => t.PlaceId == placeId && t.Type == 0).ToListAsync();
            List<Photo> allVideos = await _context.Photos!.Where(t => t.PlaceId == placeId && t.Type == 1).ToListAsync();
            if (allPhotos.Count > 0)
            {
                photos = allPhotos.Select(s => s.image!).ToList();
                // photos.Add(place!.Image!);
            }

            if (allVideos.Count > 0)
            {
                videos = allVideos.Select(s => s.image!).ToList();
            }


            return new
            {
                place = place,
                city = city,
                country = country,
                photos = photos,
                videos = videos
            };
        }




        //   list places
        public async Task<dynamic> GetPlaceDetailsList(int cityId, int index)
        {
            List<string> photos = new List<string>();
            List<string> videos = new List<string>();
            List<PlacesDetailsResponse> placesDetailsList = new List<PlacesDetailsResponse>();

            List<Place> places = await _context.Places!.Where(t => t.CityId == cityId).ToListAsync();
            City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == cityId);
            Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == city!.CountryId);


            foreach (Place item in places)
            {



                // photos.Clear();
                // videos.Clear();

                List<string> allPhotos =  _context.Photos!.Where(t => t.PlaceId == item.Id && t.Type == 0).Select(s => s.image!).ToList();
                List<string> allVideos =  _context.Photos!.Where(t => t.PlaceId == item.Id && t.Type == 1).Select(s => s.image!).ToList();
                // if (allPhotos.Count > 0)
                // {
                //     photos = allPhotos.Select(s => s.image!).ToList();
                //     // photos.Add(place!.Image!);
                // }

                // if (allVideos.Count > 0)
                // {
                //     videos = allVideos.Select(s => s.image!).ToList();
                // }
                PlacesDetailsResponse placesDetailsResponse = new PlacesDetailsResponse
                {
                    place = item,
                    city = city,
                    country = country,
                    photos = allPhotos,
                    videos = allVideos
                };

            
                placesDetailsList.Add(placesDetailsResponse);
            }
           


            return placesDetailsList.OrderByDescending(t => t.place.Id ==index);
        }



        //  


        public async Task<dynamic> GetAll()
        {
            List<Place> places = await _context.Places!.ToListAsync();




            return places;
        }




        public async Task<dynamic> GitById(int typeId)
        {
            Place? place = await _context.Places!.FirstOrDefaultAsync(x => x.Id == typeId);
            return place!;
        }

        public async Task<dynamic> GitPlacesByCityId(int typeId, int page)
        {
            List<Place> places = await _context.Places!.Where(t => t.CityId == typeId).ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(places.Count() / pageResults);

            var items = await places
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }


        public async Task<dynamic> GitPlacesByCityIdAdmin(int typeId)
        {
            List<Place> places = await _context.Places!.Where(t => t.CityId == typeId).ToListAsync();





            return places;
        }


        public async Task<dynamic> GitPlacesByCountryId(int typeId, int page)
        {
            List<Place> places = await _context.Places!.Where(t => t.CountryId == typeId).ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(places.Count() / pageResults);

            var items = await places
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }



        public async Task<dynamic> GitPlacesByCountryIdAdmin(int typeId)
        {
            List<Place> places = await _context.Places!.Where(t => t.CountryId == typeId).ToListAsync();




            return places;
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateObject(dynamic category)
        {
            //
        }
    }
}