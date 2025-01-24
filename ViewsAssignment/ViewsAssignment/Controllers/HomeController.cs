using Microsoft.AspNetCore.Mvc;
using ViewsAssignment.Models;

namespace ViewsAssignment.Controllers
{
    public class HomeController : Controller
    {
        private List<CityWeather> cityWeatherList;
        public HomeController()
        {
            cityWeatherList = new List<CityWeather>()
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

        [Route("/")]
        public IActionResult Home()
        {
            return View(cityWeatherList);
        }

        [Route("weather/{cityCode}")]
        public IActionResult CityDetails(string? cityCode)
        {
            if (cityCode is null)
                return NotFound("City code must be include");
            var city = cityWeatherList.FirstOrDefault(x => x.CityUniqueCode == cityCode);
            if (city == null) 
                return NotFound($"City with code {cityCode} Not Found");
            return View(city);
        }
    }
}
