using Microsoft.AspNetCore.Mvc;
using KillerRobots.Services;
//using KillerRobots.Models;
using Newtonsoft.Json;
using System.Drawing;
using Console = Colorful.Console;

namespace KillerRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotInjuryController : ControllerBase
{
    private readonly ILogger<RobotInjuryController> _logger;
    private readonly LocationAPI _service;


    public RobotInjuryController(LocationAPI service, ILogger<RobotInjuryController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "RobotInjury")]
    public async Task<string> Get(string LocationQuery, int NumberOfResults = 1)
    {
        string APIresponse = await _service.GetLocation(LocationQuery, NumberOfResults, LocationAPI.POI.hospital);

        Root[] myDeserializedClass = JsonConvert.DeserializeObject<Root[]>(APIresponse);
        Console.Write("Results returned Length = ", Color.DarkGreen);
        Console.WriteLine(myDeserializedClass.Length, Color.OrangeRed);
        if (myDeserializedClass.Length > 0)
            foreach (var value in myDeserializedClass) Console.WriteLine(value, Color.Yellow);
        return APIresponse;
    }
}

