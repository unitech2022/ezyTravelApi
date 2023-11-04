using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Data;
using TouristApi.ViewModel;
using TouristApi.Models;
using Microsoft.EntityFrameworkCore;
namespace TouristApi.Services.HomeService
{
    public class HomeServices : IHomeServices
    {



        private readonly AppDBcontext _context;

        public HomeServices(AppDBcontext context)
        {
            _context = context;
        }

        public async Task<ResponseHome> GetHome()
        {
            List<CityResponse> MostPopularCities = new() { };
            List<PlaceResponse> MostPopularPlaces = new() { };
            List<Photo> welcomePhotos = await _context.Photos!.Take(5).ToListAsync();
            List<Continent> continents = await _context.Continents!.OrderByDescending(t => t.status).ToListAsync();


            // ** MostPopularCities
            List<City> allCities = await _context.Cities!.Where(t => t.IsMostPopular == true).ToListAsync();

            foreach (var item in allCities)
            {
                Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == item.CountryId);

                MostPopularCities.Add(
                    new CityResponse()
                    {
                        Country = country,
                        City = item
                    }
                );


            }

            // ** MostPopularPlaces
            List<Place> allPlaces = await _context.Places!.Where(t => t.IsMostPopular == true).ToListAsync();
            foreach (var item in allPlaces)
            {
                Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == item.CountryId);
                  City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == item.CityId);

                MostPopularPlaces.Add(
                    new PlaceResponse()
                    {
                        Country = country,
                        Place = item,
                        city=city
                    }
                );


            }


            ResponseHome responseHome = new()
            {
                Welcome = welcomePhotos,
                continents = continents,
                MostPopularCities = MostPopularCities,
                MostPopularPlaces = MostPopularPlaces
            };
            return responseHome;
        }

        public async Task<ResponseHomeDashboard> GetHomeDashboard()
        {

            double continents = _context.Continents!.Count();
            double countries = _context.Countries!.Count();
            double cities = _context.Cities!.Count();
            double places = _context.Places!.Count();

            ResponseHomeDashboard responseHome = new ResponseHomeDashboard
            {
                Continents = continents,
                Countries = countries,
                Cities = cities,
                Places = places
            };

            return responseHome;

        }


    }
}