using Microsoft.AspNetCore.Mvc;

namespace WeatherBot.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("ok");
    }
}