using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Models
{
    public class Photo
    {
        public int Id { get; set; }
        
        public int PlaceId { get; set; }

        public string? image { get; set; }

    }
}