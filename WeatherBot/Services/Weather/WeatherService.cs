using Newtonsoft.Json;
using WeatherBot.Models;

namespace WeatherBot.Services.Weather;

public class WeatherService : IWeatherService
{
    
    public async Task<FullWeather?> GetWeatherAsync(string city)
    {
        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var key = "5cfbae6d10109f82c121c7880576290a";
                var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={key}&units=metric");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var fullWeather = JsonConvert.DeserializeObject<FullWeather>(stringResult);
                return fullWeather;
            }
            catch
            {
                return default;
            }
        }
    }
}