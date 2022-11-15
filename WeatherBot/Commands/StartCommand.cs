using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Commands;

public class StartCommand : ICommand
{
    private readonly ITelegramBotClient _telegramBotClient;

    public StartCommand(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public string Name => "/start";
    public async Task ExecuteAsync(Message message)
    {
        await _telegramBotClient.SendTextMessageAsync(
        chatId: message.Chat.Id,
        text: "/hello - братишка бот поприветствует тебя \n" +
              "/weather - посмотреть погоду");
    }
    
}