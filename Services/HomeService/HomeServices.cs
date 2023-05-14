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
           List<Photo> welcomePhotos=await _context.Photos!.Take(5).ToListAsync();
           List<Continent> continents=await _context.Continents!.OrderByDescending(t=>t.status).ToListAsync();

           ResponseHome responseHome=new ResponseHome{
            Welcome =welcomePhotos,
            continents=continents
           };
           return responseHome;
        }

        public async Task<ResponseHomeDashboard> GetHomeDashboard()
        {
           double continents = _context.Continents!.Count();
            double countries = _context.Countries!.Count();
            double cities = _context.Cities!.Count();
            double places = _context.Places!.Count();

            ResponseHomeDashboard responseHome =new ResponseHomeDashboard{
                Continents=continents,
                Countries=countries,
                Cities=cities,
                Places=places
            };

            return responseHome;
        }

       
    }
}