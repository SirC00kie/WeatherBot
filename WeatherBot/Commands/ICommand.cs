using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Commands;

public interface ICommand
{
    public string Name { get; }
    public Task ExecuteAsync(ITelegramBotClient botClient, Message message);
}