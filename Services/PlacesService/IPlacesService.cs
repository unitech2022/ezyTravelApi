using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Core;
using TouristApi.Models;

namespace TouristApi.Services
{
    public interface IPlacesService :BaseInterface
    {
         Task<dynamic> GitPlacesByCountryId(int typeId,int page);


         Task<dynamic> GitPlacesByCountryIdAdmin(int typeId);

           Task<dynamic> GitPlacesByCityId(int typeId,int page);

           Task<dynamic> GitPlacesByCityIdAdmin(int typeId);

           Task<dynamic> Add(Place place);

           Task<dynamic> GetPlaceDetails(int placeId);

             Task<dynamic> GetPlaceDetailsList(int cityId,int index );

           Task<dynamic> GetAll();

            Task<dynamic> GetMostPopularPlaces();
    }
}