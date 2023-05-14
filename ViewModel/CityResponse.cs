using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;

namespace TouristApi.ViewModel
{
    public class CityResponse
    {
        public Country? Country { get; set; }
        public City? City { get; set; }
    }
}