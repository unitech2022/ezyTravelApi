using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;

namespace TouristApi.ViewModel
{
    public class PlacesDetailsResponse
    {
           
           public Place place { get; set; }
           public City city { get; set; }

           public Country country { get; set; }

          public  List<string> photos { get; set; }

           public  List<string> videos { get; set; }
            // return new
            // {
            //     place = place,
            //     city = city,
            //     country = country,
            //     photos=photos,
            //     videos=videos
            // };
    }
}