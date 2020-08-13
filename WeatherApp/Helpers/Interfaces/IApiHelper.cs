using WeatherApp.Models;

namespace WeatherApp.Helpers.Classes
{
    public interface IApiHelper
    {
        WeatherModel GetWeatherInfo(string cityName);
    }
}