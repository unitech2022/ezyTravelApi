using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TouristApi.Models;

namespace TouristApi.Data
{
    public class AppDBcontext : IdentityDbContext<User>
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {



        }


        public DbSet<Continent>? Continents { get; set; }

        public DbSet<Country>? Countries { get; set; }


         public DbSet<City>? Cities { get; set; }

        public DbSet<Place>? Places { get; set; }
        public DbSet<Favorite>? Favorites { get; set; }

         public DbSet<Photo>? Photos { get; set; }


    }
}