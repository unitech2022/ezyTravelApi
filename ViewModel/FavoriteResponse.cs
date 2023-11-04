using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;

namespace TouristApi.ViewModel
{
    public class FavoriteResponse
    {
        public List<City>? Cities { get; set; }

         public List<Place>? Places { get; set; }
    }
}