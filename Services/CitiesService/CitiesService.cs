
using TouristApi.Data;
using AutoMapper;
using X.PagedList;
using TouristApi.Models.BaseEntity;
using TouristApi.Models;
using Microsoft.EntityFrameworkCore;
using TouristApi.ViewModel;
using Newtonsoft.Json;

namespace TouristApi.Services
{
    public class CitiesService : ICitiesService
    {

        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public CitiesService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic City)
        {
            await _context.Cities!.AddAsync(City);
            await _context.SaveChangesAsync();
            return City;

        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            City? City = await _context.Cities!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (City != null)
            {
                _context.Cities!.Remove(City);
                List<Photo> photos = await _context.Photos!.Where(t => t.CityId == typeId).ToListAsync();
                if (photos.Count > 0)
                {
                    _context.Photos!.RemoveRange(photos);
                }

                await _context.SaveChangesAsync();
            }

            return City!;

        }



        public async Task<CityDetails> GetCityDetails(int cityId)

        {

            // List<Photo> photos=new List<Photo>();
            City? city = await _context.Cities!.FirstOrDefaultAsync(x => x.Id == cityId);
            Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == city!.CountryId);
            ResponseWeather responseWeather = await GitWeatherOfCity(city!.Title!);

            List<Place> places = await _context.Places!.OrderBy(x => x.Order).Where(t => t.CityId == cityId).ToListAsync();
            List<Photo> photos = await _context.Photos!.Where(t => t.CityId == cityId && t.Type == 0).ToListAsync();
            List<Photo> videos = await _context.Photos!.Where(t => t.CityId == cityId && t.Type == 1).ToListAsync();
            // foreach (var item in places)
            // {
            //     List<Photo> photosFind =await _context.Photos!.Where(t => t.PlaceId==item.Id&&t.Type==0).ToListAsync();
            //     if(photosFind.Count > 0){
            //         photos.AddRange(photosFind);
            //     }
            // }

            CityDetails cityDetails = new CityDetails
            {
                city = city,
                weather = responseWeather,
                Photos = photos,
                Videos = videos,
                Places = places,
                country = country
            };

            return cityDetails;

        }


        public async Task<dynamic> GetItems(int page)
        {
            List<City> Cities = await _context.Cities!.ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(Cities.Count() / pageResults);

            var items = await Cities
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



        public async Task<dynamic> GetAllItems()
        {
            List<City> Cities = await _context.Cities!.ToListAsync();

            return Cities;
        }

        public async Task<dynamic> GitById(int typeId)
        {
            City? City = await _context.Cities!.FirstOrDefaultAsync(x => x.Id == typeId);

            return City!;
        }

        public async Task<dynamic> GitCitiesByCountryId(int typeId)
        {
            List<City> cities = new List<City>();
            Country? country;
            if (typeId == 0)
            {
                country = await _context.Countries!.FirstAsync();

                cities = await _context.Cities!.Where(t => t.CountryId == typeId).ToListAsync();

            }
            else
            {
                cities = await _context.Cities!.Where(t => t.CountryId == typeId).ToListAsync();

                country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == typeId);
            }



            ResponseCity responseCity = new ResponseCity
            {
                Country = country,
                Cities = cities
            };

            return responseCity;
        }


        public async Task<dynamic> GitCitiesByCountryIdAdmin(int typeId)
        {
            List<City> Cities = await _context.Cities!.Where(t => t.CountryId == typeId).ToListAsync();




            return Cities;
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateObject(dynamic category)
        {
            //
        }

        public async Task<dynamic> SearchCity(string textSearch)
        {
            List<CityResponse> citiesResponses = new List<CityResponse>();
            List<City> cities = await _context.Cities!.Where(t => t.Title!.Contains(textSearch)).ToListAsync();
            foreach (var item in cities)
            {
                Country? country = await _context.Countries!.FirstOrDefaultAsync(t => t.Id == item.CountryId);
                CityResponse cityResponse = new CityResponse
                {
                    City = item,
                    Country = country
                };
                citiesResponses.Add(cityResponse);
            }

            return citiesResponses;

        }
        //get weather
        async Task<ResponseWeather> GitWeatherOfCity(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?lang=ar&q={city}&appid=f99e4be1f07b9b39845b0055fd9bc2e6&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    ResponseWeather responseWeather = new ResponseWeather
                    {
                        temp = rawWeather!.Main!.Temp,
                        summary = string.Join(",", rawWeather.Weather!.Select(x => x.Description)),
                        CityName = rawWeather.Name,
                        icon = string.Join(",", rawWeather.Weather!.Select(x => x.icon)),
                    };

                    return responseWeather;
                }
                catch (HttpRequestException httpRequestException)
                {
                    return new ResponseWeather();
                }
            }

        }

        public async Task<dynamic> GetMostPopularCities()
        {
              List<City> MostPopularCities=await _context.Cities!.Where(t=> t.IsMostPopular==true).ToListAsync();
              return MostPopularCities;
        }
    }
}