using Newtonsoft.Json;

namespace WeatherBot.Models;

public class Weather
{
    [JsonProperty("description", Required = Required.Always)]
    public string Description { get; set; } = null!;
}