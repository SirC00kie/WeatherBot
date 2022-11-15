
using WeatherBot.Models;

namespace WeatherBot.Services.Weather;

public interface IWeatherService
{
    public Task<FullWeather?> GetWeatherAsync(string city);
}