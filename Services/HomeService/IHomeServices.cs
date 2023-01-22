using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.ViewModel;

namespace TouristApi.Services.HomeService
{
    public interface IHomeServices
    {
         Task<ResponseHomeDashboard> GetHomeDashboard();

          Task<ResponseHome> GetHome();
    }
}