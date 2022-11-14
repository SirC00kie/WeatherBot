using Microsoft.AspNetCore.Mvc;

namespace WeatherBot.Contollers;

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