using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot;
using WeatherBot.Commands;
using WeatherBot.Services;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;
    var token = configuration["Token"];
    var hostingUrl = configuration["Url"];
    
    var telegramBotClient = new TelegramBotClient(token);
    var webHookUrl = hostingUrl + "api/update";
    await telegramBotClient.SetWebhookAsync(webHookUrl);

    builder.Services
        .AddScoped<ICommandExecutor, CommandExecutor>()
        .AddSingleton<ITelegramBotClient>(telegramBotClient)
        .AddSingleton<ICommand, HelloCommand>();
    
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        var settings = options.SerializerSettings;
        settings.Formatting = Formatting.Indented;
        settings.ContractResolver = new DefaultContractResolver();
    });
}


var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

