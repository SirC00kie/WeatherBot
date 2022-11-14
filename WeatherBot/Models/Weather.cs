namespace WeatherBot.Models;

public class Weather
{
    public double Temperature { get; set; }
    public double TemperatureFeels { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
    public double Clouds { get; set; }
    public double WindSpeed { get; set; }
    public string Description { get; set; } = string.Empty;
}   