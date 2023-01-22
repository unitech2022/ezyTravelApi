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
    public class CitiesService : ICitiesService
    {

        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public CitiesService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic City)
        {
            await _context.Cities!.AddAsync(City);
            await _context.SaveChangesAsync();
            return City;

        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            City? City = await _context.Cities!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (City != null)
            {
                _context.Cities!.Remove(City);

                await _context.SaveChangesAsync();
            }

            return City!;

        }

        public async Task<dynamic> GetItems(int page)
        {
            List<City> Cities = await _context.Cities!.ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(Cities.Count() / pageResults);

            var items = await Cities
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



        public async Task<dynamic> GetAllItems()
        {
            List<City> Cities = await _context.Cities!.ToListAsync();

            return Cities;
        }

        public async Task<dynamic> GitById(int typeId)
        {
            City? City = await _context.Cities!.FirstOrDefaultAsync(x => x.Id == typeId);
            return City!;
        }

        public async Task<dynamic> GitCitiesByCountryId(int typeId, int page)
        {
            List<City> Cities = await _context.Cities!.Where(t => t.CountryId == typeId).ToListAsync();

            Country? country=await _context.Countries!.FirstOrDefaultAsync(t=>t.Id==typeId);

            var pageResults = 30f;
            var pageCount = Math.Ceiling(Cities.Count() / pageResults);

            var items = await Cities
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


  public async Task<dynamic> GitCitiesByCountryIdAdmin(int typeId)
        {
            List<City> Cities = await _context.Cities!.Where(t => t.CountryId == typeId).ToListAsync();



          
            return Cities;
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