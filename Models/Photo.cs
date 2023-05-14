using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Models
{

    // type= 0 photo  =1 video;
    public class Photo
    {
        public int Id { get; set; }
        
        public int PlaceId { get; set; }
   

         public int CityId { get; set; }

         public int Type { get; set; }

        public string? image { get; set; }

    }
}