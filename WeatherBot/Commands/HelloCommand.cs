using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Commands;

public class HelloCommand : ICommand
{
    public string Name => "/hello";
    public async Task ExecuteAsync(Message message, ITelegramBotClient botClient)
    {
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Привет, {message.Chat.FirstName} {message.Chat.LastName}!\n" +
                  $"Ты в самом крутом боте (наверное?) для отображения погоды (в любой деревне?) \n" +
                  $"Пример: /weather Moscow");
    }
    
}