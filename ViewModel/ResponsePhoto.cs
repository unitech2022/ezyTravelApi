using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;

namespace TouristApi.ViewModel
{
    public class ResponsePhoto
    {
        public Photo? photo { get; set; }
        public City? city { get; set; }

        public Country? country { get; set; }
    }
}