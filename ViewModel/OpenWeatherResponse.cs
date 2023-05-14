
namespace TouristApi.ViewModel
{
public class OpenWeatherResponse
    {
        public string? Name { get; set; }

        public IEnumerable<WeatherDescription>? Weather { get; set; }

        public Main? Main { get; set; }
    }

    public class WeatherDescription
    {
        public string? Main { get; set; }

        public string? icon { get; set; }
        public string? Description { get; set; }
    }

    public class Main
    {
        public string? Temp { get; set; }
    }


    public class ResponseWeather{
      public string? CityName { get; set; }
       public string? temp { get; set; }
        public string? summary { get; set; }
         public string? icon { get; set; }
    }

}

