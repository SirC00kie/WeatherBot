using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Commands;

public class StartCommand : ICommand
{
    public string Name => "start";
    public async Task ExecuteAsync(ITelegramBotClient botClient, Message message)
    {
        await botClient.SendTextMessageAsync(
        chatId: message.Chat.Id,
        text: "Start");
    }
}