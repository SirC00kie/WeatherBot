using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Commands;

public class BaseCommand : ICommand
{
    public string Name => "";
    public async Task ExecuteAsync(Message message, ITelegramBotClient botClient)
    {
        await botClient.SendTextMessageAsync(
        chatId: message.Chat.Id,
        text: "/hello - Братишка-бот поприветствует тебя \n" +
              "/weather - посмотреть погоду в заданном городе \n" +
              "Пример: /weather Moscow");
    }
    
}