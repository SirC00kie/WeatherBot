using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot;
using WeatherBot.Services.Command;
using WeatherBot.Services.Weather;

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
        .AddSingleton<IWeatherService, WeatherService>()
        .AddSingleton<ITelegramBotClient>(telegramBotClient)
        .AddHttpClient("weather", client =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
        });


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

