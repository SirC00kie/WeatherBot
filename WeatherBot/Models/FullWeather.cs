using Newtonsoft.Json;

namespace WeatherBot.Models;

public class FullWeather
{
    [JsonProperty("name", Required = Required.Always)]
    public string Name { get; set; } = null!;

    [JsonProperty("weather", Required = Required.Always)]
    public IEnumerable<Weather> Weather { get; set; } = null!;

    [JsonProperty("main", Required = Required.Always)]
    public Main Main { get; set; } = null!;

    [JsonProperty("wind", Required = Required.Always)]
    public Wind Wind { get; set; } = null!;

    [JsonProperty("clouds", Required = Required.Always)]
    public Clouds Clouds { get; set; } = null!;
}   