using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Services.Weather;

namespace WeatherBot.Commands;

public class WeatherCommand : ICommand
{
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IWeatherService _weatherService;

    public WeatherCommand(ITelegramBotClient telegramBotClient, IWeatherService weatherService)
    {
        _telegramBotClient = telegramBotClient;
        _weatherService = weatherService;
    }

    public string Name => $"/weather";
    public async Task ExecuteAsync(Message message)
    {
        var city = message.Text.Substring(Name.Length);

        if (city != null)
        {
            var weather = await _weatherService.GetWeatherAsync(city);

            if (weather != null)
            {
                var text = $"Город: {weather.Name} \n" +
                           $"Тепература: {weather.Main.Temperature}, ℃ \n" +
                           $"Чувствуется как {weather.Main.TemperatureFeels}, ℃ \n" +
                           $"Давление: {weather.Main.Pressure}, мм рт. ст." +
                           $"Влажность: {weather.Main.Humidity}, %" +
                           $"Облачность: {weather.Clouds.Procent}, %" +
                           $"Ветер: {weather.Wind.Speed}, м/с" +
                           $"Описание: {weather.Weather.Description}";
            
                await _telegramBotClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: text);
            }
            await _telegramBotClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Команда введена неверна. Проверьте введеренны город: {city}");
        }
        await _telegramBotClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Команда введена неверна.");

        
    }
}