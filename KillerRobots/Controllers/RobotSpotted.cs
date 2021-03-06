using Microsoft.AspNetCore.Mvc;
using KillerRobots.Services;
using Newtonsoft.Json;
using System.Drawing;
using Console = Colorful.Console;

namespace KillerRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotSpottedController : ControllerBase
{
    private readonly ILogger<RobotSpottedController> _logger;
    private readonly WebRequests _service;

    public RobotSpottedController(WebRequests service, ILogger<RobotSpottedController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "RobotSpotted")]
    public async Task<object> Get(string LocationQuery, int NumberOfResults = 1)
    {
        string IPcheck = await _service.IPgeolocation();
        IPLocationCheck DeserializedIPCheck = new IPLocationCheck();
        DeserializedIPCheck = JsonConvert.DeserializeObject<IPLocationCheck>(IPcheck);

        if (DeserializedIPCheck.countryCode != "AU")
        {
            DeserializedIPCheck.rejectionMessage();

            return Problem
                (
                type: "/docs/errors/forbidden",
                title: "Un-Authorsied Geo-Location",
                detail: $"Request orignated from outside of Australia. " +
                $"IP: {DeserializedIPCheck.query} - {DeserializedIPCheck.city}, " +
                $"{DeserializedIPCheck.country}",
                statusCode: StatusCodes.Status403Forbidden,
                instance: HttpContext.Request.Path
                );
        }

        string APIresponse = await _service.GetLocation(LocationQuery, NumberOfResults, WebRequests.POI.water);

        LocationData[] myDeserializedClass = JsonConvert.DeserializeObject<LocationData[]>(APIresponse);
        Console.Write("Results returned Length = ",  Color.DarkGreen);
        Console.WriteLine(myDeserializedClass.Length, Color.OrangeRed);
        if(myDeserializedClass.Length > 0)
            foreach (var value in myDeserializedClass) Console.WriteLine(value, Color.Yellow);
        return APIresponse;
    }
}

