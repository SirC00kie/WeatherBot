using Newtonsoft.Json;

namespace WeatherBot.Models;

public class Main
{
    [JsonProperty("temp", Required = Required.Always)]
    public double Temperature { get; set; }
    
    [JsonProperty("feels_like", Required = Required.Always)]
    public double TemperatureFeels { get; set; }
    
    [JsonProperty("pressure", Required = Required.Always)]
    public double Pressure { get; set; }
    
    [JsonProperty("humidity", Required = Required.Always)]
    public double Humidity { get; set; }
}