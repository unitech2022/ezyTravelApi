using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TouristApi.Data;
using TouristApi.Models;
using TouristApi.Models.BaseEntity;
using TouristApi.ViewModel;
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

        public async Task<dynamic> DeleteAsync(int typeId)
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
            var data = await _context.Photos!.ToListAsync();
            return data;
        }

        public async Task<dynamic> GetItems(int page)
        {
            List<ResponsePhoto> photos = new List<ResponsePhoto>();
            List<Photo> allPhotos = await _context.Photos!.Where(t => t.Type == 0).ToListAsync();
            foreach (var item in allPhotos)
            {
                City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == item.CityId);
                Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == city!.CountryId);
                ResponsePhoto responsePhoto = new ResponsePhoto
                {
                    photo = item,
                    country = country,
                    city = city
                };
                photos.Add(responsePhoto);
            }



            var pageResults = 10f;
            var pageCount = Math.Ceiling(photos.Count() / pageResults);

            var items = await photos
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

        public async Task<dynamic> GetPhotosByPlaceId(int cityId, int page)
        {
            List<ResponsePhoto> responsePhotos = new List<ResponsePhoto>();
            List<Photo> photos = new List<Photo>();
            if (cityId == 0)
            {
                photos = await _context.Photos!.Where(t => t.Type == 0).ToListAsync();
                foreach (var item in photos)
                {
                    City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == item.CityId);
                    Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == city!.CountryId);
                    ResponsePhoto responsePhoto = new ResponsePhoto
                    {
                        photo = item,
                        country = country,
                        city = city
                    };
                    responsePhotos.Add(responsePhoto);
                }


            }
            else
            {
                List<Place> places = await _context.Places!.Where(t => t.CityId == cityId).ToListAsync();

                foreach (var item in places)
                {
                    Photo? photo = await _context.Photos!.FirstOrDefaultAsync(t => t.PlaceId == item.Id);

                    if (photo != null)
                    {
                        City? city = await _context.Cities!.FirstOrDefaultAsync(t => t.Id == photo.CityId);
                        Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == city!.CountryId);
                        ResponsePhoto responsePhoto = new ResponsePhoto
                        {
                            photo = photo,
                            country = country,
                            city = city
                        };
                        responsePhotos.Add(responsePhoto);
                        // photos.Add(photo);
                    }

                }

                // photos = await _context.Photos!.Where(t => t.PlaceId == placeId).ToListAsync();
            }




            var pageResults = 10f;
            var pageCount = Math.Ceiling(responsePhotos.Count() / pageResults);

            var items = await responsePhotos
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

        public async Task<dynamic> GetVideos(int page)
        {
            List<Photo> Countries = await _context.Photos!.Where(t => t.Type == 1).ToListAsync();



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