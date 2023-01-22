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
    public class CountriesService : ICountriesService
    {

         private readonly IMapper _mapper;

       
        private readonly AppDBcontext _context;

        public CountriesService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async  Task<dynamic> AddAsync(dynamic Country)
        {
            await _context.Countries!.AddAsync(Country);
            await _context.SaveChangesAsync();
            return Country;
            
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
             Country? country = await _context.Countries!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (country != null)
            {
                _context.Countries!.Remove(country);

                await _context.SaveChangesAsync();
            }

            return country!;
        
        }

        public async Task<dynamic> GetItems( int page)
        {
             List<Country> Countries = await _context.Countries!.ToListAsync();
           


            var pageResults = 10f;
            var pageCount = Math.Ceiling(Countries.Count() / pageResults);

            var items = await Countries
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

       public async Task<dynamic> GitAllCountries( )
        {
             List<Country> Countries = await _context.Countries!.ToListAsync();
           



            return Countries;
        }


        public async Task<dynamic> GitCountriesByContinentId(int typeId)
        {
             List<Country> Countries = await _context.Countries!.Where(t => t.ContinentId==typeId).ToListAsync();
           


            // var pageResults = 10f;
            // var pageCount = Math.Ceiling(Countries.Count() / pageResults);

            // var items = await Countries
            //     .Skip((page - 1) * (int)pageResults)
            //     .Take((int)pageResults)
            //     .ToListAsync();



            // BaseResponse baseResponse = new BaseResponse
            // {
            //     Items = items,
            //     CurrentPage = page,
            //     TotalPages = (int)pageCount
            // };

            return Countries;
        }

        public async Task<dynamic> GitById(int typeId)
        {
            Country? Country = await _context.Countries!.FirstOrDefaultAsync(x => x.Id == typeId);
            return Country!;
        }

        public  bool SaveChanges()
        {
               return (_context.SaveChanges() >= 0);
        }

        public  void UpdateObject(dynamic category)
        {
           //
        }
    
    
    
    
    
    }


   
}