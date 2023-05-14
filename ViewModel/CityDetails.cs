using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;

namespace TouristApi.ViewModel
{
    public class CityDetails
    {
        public City? city { get; set; }


        public Country? country { get; set; }
        public ResponseWeather? weather { get; set; }


        public List<Place>? Places { get; set; }

        public List<Photo>? Photos { get; set; }

         public List<Photo>? Videos { get; set; }


    }
}