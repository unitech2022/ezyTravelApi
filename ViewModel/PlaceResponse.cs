using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;

namespace TouristApi.ViewModel
{
    public class PlaceResponse
    {
        public Country? Country { get; set; }
        public Place? Place { get; set; }

        public City? city { get; set; }
    }
}