using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;

namespace TouristApi.ViewModel
{
    public class ResponseHome 
    {

      public List<Photo>? Welcome { get; set; }

    public List<Continent>? continents { get; set; }



    }
}