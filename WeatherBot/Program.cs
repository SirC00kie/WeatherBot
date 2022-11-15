using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot;
using WeatherBot.Services.Command;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;
    var token = configuration["Token"];
    var hostingUrl = configuration["Url"];
    
    var telegramBotClient = new TelegramBotClient(token);
    var webHookUrl = hostingUrl + "api/update";
    await telegramBotClient.SetWebhookAsync(webHookUrl);

    builder.Services
        .AddScoped<ICommandService, CommandService>()
        .AddSingleton<ITelegramBotClient>(telegramBotClient);

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

