using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using WeatherBot.Services.Command;

namespace WeatherBot.Controllers;

[Route("api/update")]
[ApiController]
public class WeatherBotController : ControllerBase
{
    private readonly ICommandService _commandService;

    public WeatherBotController(ICommandService commandService)
    {
        _commandService = commandService;
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] Update update)
    {
        var message = update.Message;
        
        if (message != null)
        {
            var command = _commandService.Execute(message);
            await command.ExecuteAsync(message);
        }
        
        return Ok("");
    }
}