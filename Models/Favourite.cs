using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouristApi.Models
{
    public class Favorite
    {
     

        // id placeId likes updatedAt

        public int Id { get; set; }
         public int PlaceId { get; set; }
         public double Likes { get; set; }

         public DateTime UpdatedAt { get; set; }

            public Favorite()
        {
         
            UpdatedAt = DateTime.Now;
        }
    }
}