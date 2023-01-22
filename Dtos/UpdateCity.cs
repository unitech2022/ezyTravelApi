using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Dtos
{
    public class UpdateCity
    {
           public int CountryId { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }
        public int status { get; set; }
    }
}