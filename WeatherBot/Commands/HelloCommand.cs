using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Commands;

public class HelloCommand : ICommand
{
    public string Name => "hello";
    public async Task ExecuteAsync(ITelegramBotClient botClient, Message message)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Hello");
    }
}