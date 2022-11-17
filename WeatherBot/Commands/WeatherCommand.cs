using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Services.Weather;

namespace WeatherBot.Commands;

public class WeatherCommand : ICommand
{
    private readonly IWeatherService _weatherService;

    public WeatherCommand(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public string Name => $"/weather";
    public async Task ExecuteAsync(Message message, ITelegramBotClient botClient)
    {
        var messageText = message.Text;
        
        if (messageText?.Length <= Name.Length)
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Город не введен.");
            return;
        }
        var city = messageText?.Substring(Name.Length + 1);

        var weather = await _weatherService.GetWeatherAsync(city!);

        if (weather == null)
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Команда введена неверна. Проверьте введенный город: {city}");
            return;
        }

        var mainWeather = weather.Main;

        var text = $"Город: {weather.Name} \n" +
                   $"Тепература: {mainWeather.Temperature}, ℃ \n" +
                   $"Чувствуется как {mainWeather.TemperatureFeels}, ℃ \n" +
                   $"Давление: {mainWeather.Pressure}, мм рт. ст. \n" +
                   $"Влажность: {mainWeather.Humidity}, % \n" +
                   $"Облачность: {weather.Clouds.Procent}, % \n" +
                   $"Ветер: {weather.Wind.Speed}, м/с \n" +
                   $"Описание: {weather.Weather.FirstOrDefault()?.Description}";
            
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: text);
    }
}