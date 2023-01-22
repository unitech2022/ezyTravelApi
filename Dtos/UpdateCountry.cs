using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Dtos
{
    public class UpdateCountry
    {
              public int ContinentId { get; set; }

        public string? Language { get; set; }

        public string? Currency { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int status { get; set; }
    }
}