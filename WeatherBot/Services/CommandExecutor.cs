using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherBot.Commands;

namespace WeatherBot.Services;

public class CommandExecutor : ICommandExecutor
{
    private readonly ICommand _command;
    private readonly IReadOnlyCollection<ICommand> _commands;

    public CommandExecutor(ITelegramBotClient telegramBotClient)
    {
        //todo
        _command = new StartCommand();
        _commands = new ICommand[]
        {
            new HelloCommand()
        };  
    }

    public ICommand Execute(Message message)
    {
        //todo
        var messageText = message.Text;
        var command = _commands.SingleOrDefault(c => c.Name == messageText);

        if (command != null)
        {
            return command;
        }

        return _command;
    }
}