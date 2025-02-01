using Models;
using WeatherService;

namespace WeatherServiceLibrary
{
    public class WeatherService : IWeatherService
    {
        private readonly IEnumerable<CityWeather> _cityWeather;
        public WeatherService()
        {
            _cityWeather = new List<CityWeather>()
            {
                new CityWeather()
                {
                    CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33
                },
                new CityWeather()
                {
                    CityUniqueCode = "NYC", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60
                },
                new CityWeather()
                {
                    CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82
                }
            };
        }

        public string GetColor(int? temp)
        {
            if (temp < 44) return "blue";
            if (temp <= 74) return "yellow";
            return "orange";
        }

        public IEnumerable<string> GetColors()
        {
            List<string> colors = new List<string>();
            foreach(var city in _cityWeather)
                colors.Add(GetColor(city.TemperatureFahrenheit));
            return colors;
        }

        public CityWeather? GetWeatherByCityCode(string CityCode)
        {
            return _cityWeather.FirstOrDefault(x => x.CityUniqueCode == CityCode);
        }

        public IEnumerable<CityWeather> GetWeatherDetails()
        {
            return _cityWeather;
        }
    }
}
