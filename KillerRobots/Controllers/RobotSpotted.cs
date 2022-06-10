using Microsoft.AspNetCore.Mvc;
using KillerRobots.Services;


namespace KillerRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotSpottedController : ControllerBase
{
    private readonly ILogger<RobotSpottedController> _logger;
    private readonly LocationAPI _service;

    public RobotSpottedController(LocationAPI service, ILogger<RobotSpottedController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public async Task<string> Get()
    {
        return "x";
    }
}

