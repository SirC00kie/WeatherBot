using Newtonsoft.Json;

namespace WeatherBot.Models;

public class Wind
{
    [JsonProperty("speed", Required = Required.Always)]
    public double Speed { get; set; }
}