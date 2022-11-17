using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Commands;
using WeatherBot.Services.Weather;

namespace WeatherBot.Services.Command;

public class CommandService : ICommandService
{
    private readonly ICommand _command;
    private readonly IReadOnlyCollection<ICommand> _commands;

    public CommandService(IWeatherService weatherService)
    {
        _command = new BaseCommand();
        _commands = new ICommand[]
        {
            new HelloCommand(),
            new WeatherCommand(weatherService)
        };  
    }

    public ICommand Execute(Message message)
    {
        
        var messageText = message.Text;
        var command = _commands.SingleOrDefault(c => c.Name.Length <= messageText.Length &&
                                                     c.Name == messageText.Substring(0, c.Name.Length));
        
        if (command != null)
        {
            return command;
        }

        return _command;
    }
}