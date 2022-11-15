using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Commands;

namespace WeatherBot.Services.Command;

public class CommandService : ICommandService
{
    private readonly ICommand _command;
    private readonly IReadOnlyCollection<ICommand> _commands;

    public CommandService(ITelegramBotClient telegramBotClient)
    {
        _command = new StartCommand(telegramBotClient);
        _commands = new ICommand[]
        {
            new HelloCommand(telegramBotClient),
            new StartCommand(telegramBotClient)
        };  
    }

    public ICommand Execute(Message message)
    {
        
        var messageText = message.Text;
        var command = _commands.SingleOrDefault(c => c.Name == messageText);

        if (command != null)
        {
            return command;
        }

        return _command;
    }
}