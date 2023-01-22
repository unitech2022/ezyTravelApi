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