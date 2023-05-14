using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;

namespace TouristApi.ViewModel
{
    public class ResponseCity 
    {
        public Country? Country { get; set; }
        public List<City>? Cities { get; set; }
    }
}