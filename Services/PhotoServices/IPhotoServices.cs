using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Core;

namespace TouristApi.Services.PhotoServices
{
    public interface IPhotoServices :BaseInterface
    {
         Task<dynamic> GetAllPhots();

        Task<dynamic> GetPhotosByPlaceId(int cityId,int page);

        Task<dynamic> GetVideos(int page);
    }
}