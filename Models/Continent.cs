using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int status { get; set; }
        public DateTime CreatedAt { get; set; }


           public Continent()
        {
         
            CreatedAt = DateTime.Now;
        }
    }
}