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
    public class ContinentsService : IContinentsService
    {

         private readonly IMapper _mapper;

       
        private readonly AppDBcontext _context;

        public ContinentsService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async  Task<dynamic> AddAsync(dynamic continent)
        {
            await _context.Continents!.AddAsync(continent);
            await _context.SaveChangesAsync();
            return continent;
            
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
             Continent? continent = await _context.Continents!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (continent != null)
            {
                _context.Continents!.Remove(continent);

                await _context.SaveChangesAsync();
            }

            return continent!;
        
        }

        public async Task<dynamic> GetItemsAll()
        {
             List<Continent> continents = await _context.Continents!.ToListAsync();
           


       
            return continents;
        }

        public async Task<dynamic> GetItems( int page)
        {
             List<Continent> continents = await _context.Continents!.ToListAsync();
           


            var pageResults = 10f;
            var pageCount = Math.Ceiling(continents.Count() / pageResults);

            var items = await continents
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

        public async Task<dynamic> GitById(int typeId)
        {
            Continent? continent = await _context.Continents!.FirstOrDefaultAsync(x => x.Id == typeId);
            return continent!;
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