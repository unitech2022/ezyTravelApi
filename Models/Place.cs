using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Models
{
    // id title desc countryId image  status createAt 

    public class Place
    {
        public int Id { get; set; }

        public int CountryId { get; set; }


        public int CityId { get; set; }
        public string? Title { get; set; }

        public string? Desc { get; set; }

        public string? Image { get; set; }
        public int status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Place()
        {

            CreatedAt = DateTime.Now;
        }
    }
}
