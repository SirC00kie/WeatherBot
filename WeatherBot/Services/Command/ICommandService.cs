using Telegram.Bot.Types;
using WeatherBot.Commands;

namespace WeatherBot.Services.Command;

public interface ICommandService
{
    ICommand Execute(Message message);
}