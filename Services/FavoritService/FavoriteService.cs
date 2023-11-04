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
    public class FavoriteService : IFavoriteService
    {

        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public FavoriteService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic Favorite)
        {
            await _context.Favorites!.AddAsync(Favorite);
            await _context.SaveChangesAsync();
            return Favorite;

        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Favorite? Favorite = await _context.Favorites!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (Favorite != null)
            {
                _context.Favorites!.Remove(Favorite);

                await _context.SaveChangesAsync();
            }

            return Favorite!;

        }

        public async Task<dynamic> GetFavorites(string ids, string idsPlace)
        {
            List<City> cities = new List<City>();
            List<Place> places = new List<Place>();

            // ** getCities
            string[] idsCities = new string[] { };
            if (ids != null)
            {
                idsCities = ids.Split("#");
            }


            foreach (var item in idsCities)
            {
                City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == int.Parse(item));
                if (city != null)
                {
                    cities.Add(city);
                }
            }

            //** get places
            string[] newIdsPlaces = new string[] { };
            if (ids != null)
            {
                newIdsPlaces = idsPlace.Split("#");
            }


            foreach (var item in newIdsPlaces)
            {
                Place? place = await _context.Places!.FirstOrDefaultAsync(t => t.Id == int.Parse(item));
                if (place != null)
                {
                    places.Add(place);
                }
            }

            FavoriteResponse favoriteResponse = new FavoriteResponse
            {
                Cities = cities,
                Places = places
            };


            return favoriteResponse;
        }

        public async Task<dynamic> GetItems(int page)
        {
            List<Favorite> Favorites = await _context.Favorites!.ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(Favorites.Count() / pageResults);

            var items = await Favorites
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
            Favorite? Favorite = await _context.Favorites!.FirstOrDefaultAsync(x => x.Id == typeId);
            return Favorite!;
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