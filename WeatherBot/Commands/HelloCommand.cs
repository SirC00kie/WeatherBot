using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherBot.Commands;

public class HelloCommand : ICommand
{
    private readonly ITelegramBotClient _telegramBotClient;

    public HelloCommand(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public string Name => "/hello";
    public async Task ExecuteAsync(Message message)
    {
        await _telegramBotClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"Привет, {message.Chat.FirstName}!\n" +
                  $"Ты в самом крутом боте для отображения погоды, показывает даже станицу скобелевскую (никто не знает где она) \n" +
                  $"Чтобы посмотреть команды напиши: /start");
    }


}