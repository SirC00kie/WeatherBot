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

    //TODO: Обработать город 
    public string Name => $"/weather";
    public Task ExecuteAsync(Message message)
    {
        throw new NotImplementedException();
    }
}