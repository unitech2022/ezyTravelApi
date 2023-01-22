using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Core;

namespace TouristApi.Services
{
    public interface ICountriesService :BaseInterface
    {
         Task<dynamic> GitCountriesByContinentId(int typeId);

          Task<dynamic> GitAllCountries();

          
    }
}