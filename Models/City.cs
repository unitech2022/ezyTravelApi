using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Models
{
    // id title desc countryId image  status createAt 

    public class City
    {
          public int Id { get; set; }

        public int CountryId { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        // public string? ImageFlag { get; set; }
        public bool IsMostPopular { get; set; }
        public int status { get; set; }
        public DateTime CreatedAt { get; set; }

           public City()
        {
         
            CreatedAt = DateTime.Now;
        }
    }
    }