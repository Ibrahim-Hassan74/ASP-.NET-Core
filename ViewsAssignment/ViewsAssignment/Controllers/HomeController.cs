using Microsoft.AspNetCore.Mvc;
using WeatherService;


namespace ViewsAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Home()
        {
            ViewBag.Colors = _weatherService.GetColors();
            return View(_weatherService.GetWeatherDetails());
        }

        [Route("weather/{cityCode}")]
        public IActionResult CityDetails(string? cityCode)
        {
            if (cityCode is null)
                return NotFound("City code must be include");
            var city = _weatherService.GetWeatherByCityCode(cityCode);
            if (city == null) 
                return NotFound($"City with code {cityCode} Not Found");
            ViewBag.color = _weatherService.GetColor(city.TemperatureFahrenheit);
            return View(city);
        }
    }
}
