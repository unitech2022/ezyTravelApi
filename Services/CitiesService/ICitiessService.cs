using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Core;
using TouristApi.ViewModel;

namespace TouristApi.Services
{
    public interface ICitiesService :BaseInterface
    {
          Task<dynamic> GitCitiesByCountryId(int typeId);

           Task<dynamic> GitCitiesByCountryIdAdmin(int typeId);
           Task<dynamic> GetAllItems();

           Task<CityDetails> GetCityDetails(int cityId);

       Task<dynamic> SearchCity(string text);


          
    }
}