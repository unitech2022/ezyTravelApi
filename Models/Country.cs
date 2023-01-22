using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Models
{

    // id name image  continentId currency language status createdAt
    public class Country
    {
        public int Id { get; set; }

        public int ContinentId { get; set; }

        public string? Language { get; set; }

        public string? Currency { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int status { get; set; }
        public DateTime CreatedAt { get; set; }


          public Country()
        {
         
            CreatedAt = DateTime.Now;
        }
    }
}