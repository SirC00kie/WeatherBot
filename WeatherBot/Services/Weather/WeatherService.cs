using Newtonsoft.Json;
using WeatherBot.Models;

namespace WeatherBot.Services.Weather;

public class WeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<FullWeather?> GetWeatherAsync(string city)
    {
        var client = _httpClientFactory.CreateClient("weather");
        var key = "5cfbae6d10109f82c121c7880576290a";

        var uriBuilder = new UriBuilder
        {
            Scheme = "http",
            Host = "api.openweathermap.org",
            Path = "/data/2.5/weather",
            Query = $"q={city}&appid={key}&units=metric"
        };
        var uri = uriBuilder.Uri;

        try
        {
            var stringResult = await client.GetStringAsync(uri);
            var fullWeather = JsonConvert.DeserializeObject<FullWeather>(stringResult);
            return fullWeather;
        }
        catch
        {
            return default;
        }
        
    }
}