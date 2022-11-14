using Telegram.Bot.Types;
using WeatherBot.Commands;

namespace WeatherBot.Services;

public interface ICommandExecutor
{
    ICommand Execute(Message message);
}