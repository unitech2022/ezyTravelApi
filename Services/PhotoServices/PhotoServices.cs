using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TouristApi.Data;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;
using X.PagedList;

namespace TouristApi.Services.PhotoServices
{
    public class PhotoServices : IPhotoServices
        
 
    {

  private readonly AppDBcontext _context;

        public PhotoServices(AppDBcontext context)
        {
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
            await _context.Photos!.AddAsync(type);
            await _context.SaveChangesAsync();
            return type;
        }

        public  async Task<dynamic> DeleteAsync(int typeId)
        {
            Photo? photo = await _context.Photos!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (photo != null)
            {
                _context.Photos!.Remove(photo);

                await _context.SaveChangesAsync();
            }

            return photo!;
        }

        public async Task<dynamic> GetAllPhots()
        {
           var data =await _context.Photos!.ToListAsync();
           return data;
        }

        public async Task<dynamic> GetItems(int page)
        {
           List<Photo> Countries = await _context.Photos!.ToListAsync();
           


            var pageResults = 10f;
            var pageCount = Math.Ceiling(Countries.Count() / pageResults);

            var items = await Countries
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }

        public Task<dynamic> GitById(int typeId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
          return (_context.SaveChanges() >= 0);
        }

        public void UpdateObject(dynamic category)
        {
            throw new NotImplementedException();
        }
    }
}