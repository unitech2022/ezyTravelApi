using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Core;

namespace TouristApi.Services
{
    public interface ICitiesService :BaseInterface
    {
          Task<dynamic> GitCitiesByCountryId(int typeId,int page);

           Task<dynamic> GitCitiesByCountryIdAdmin(int typeId);
           Task<dynamic> GetAllItems();

          
    }
}