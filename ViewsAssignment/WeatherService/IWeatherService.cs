using Models;

namespace WeatherService
{
    public interface IWeatherService
    {
        IEnumerable<CityWeather> GetWeatherDetails();
        CityWeather? GetWeatherByCityCode(string CityCode);
        string GetColor(int? temp);
        IEnumerable<string> GetColors();
    }
}