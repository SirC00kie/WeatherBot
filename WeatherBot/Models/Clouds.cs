using Newtonsoft.Json;

namespace WeatherBot.Models;

public class Clouds
{
    [JsonProperty("all", Required = Required.Always)]
    public double Procent { get; set; }
}