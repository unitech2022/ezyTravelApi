using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Core;

namespace TouristApi.Services
{
    public interface IFavoriteService :BaseInterface
    {
         Task<dynamic> GetFavorites(string ids,string idsPlace);
    }
}