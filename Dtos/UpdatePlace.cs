using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Dtos
{
    public class UpdatePlace
    {
        public int CountryId { get; set; }

  public string? LatLng { get; set; }
        //   public double Lng { get; set; }
           public string? AddressName { get; set; }
        public int CityId { get; set; }
        public string? Title { get; set; }

        public string? Desc { get; set; }
 public bool IsMostPopular { get; set; }
        public string? Image { get; set; }
        public int status { get; set; }
    }
}