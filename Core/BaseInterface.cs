using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouristApi.Models.BaseEntity;

namespace TouristApi.Core
{
    public interface BaseInterface 
    {

       Task<dynamic> GetItems(int page);


        Task<dynamic> AddAsync(dynamic type);

         Task<dynamic> GitById(int typeId);


        Task<dynamic> DeleteAsync(int typeId);

        void UpdateObject(dynamic category);


         bool SaveChanges();
    }
}