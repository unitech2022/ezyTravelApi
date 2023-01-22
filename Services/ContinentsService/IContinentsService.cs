using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Core;

namespace TouristApi.Services
{
    public interface IContinentsService :BaseInterface
    {
         Task<dynamic> GetItemsAll();
    }
}