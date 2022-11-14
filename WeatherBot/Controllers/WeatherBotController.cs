using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using WeatherBot.Services;

namespace WeatherBot.Controllers;

[Route("api/update")]
[ApiController]
public class WeatherBotController : ControllerBase
{
    private readonly ICommandExecutor _commandExecutor;

    public WeatherBotController(ICommandExecutor commandExecutor)
    {
        _commandExecutor = commandExecutor;
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] Update update)
    {
        var message = update.Message;

        //todo
        if (message != null)
        {
            var command = _commandExecutor.Execute(message);
            await command.ExecuteAsync(message);
        }
        
        return Ok("123");
    }
}