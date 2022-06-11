using Microsoft.AspNetCore.Mvc;
using KillerRobots.Services;
using Newtonsoft.Json;
using System.Drawing;
using Console = Colorful.Console;

namespace KillerRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class RobotBountyController : ControllerBase
{
    private readonly ILogger<RobotBountyController> _logger;
    private readonly WebRequests _service;

    public RobotBountyController(WebRequests service, ILogger<RobotBountyController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "RobotBounty")]
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

        string APIresponse = await _service.GetLocation(LocationQuery, NumberOfResults, WebRequests.POI.police);

        LocationData[] DeserializedAPIresponse = JsonConvert.DeserializeObject<LocationData[]>(APIresponse);
        Console.Write("Results returned Length = ", Color.DarkGreen);
        Console.WriteLine(DeserializedAPIresponse.Length, Color.OrangeRed);
        if (DeserializedAPIresponse.Length > 0)
            foreach (var value in DeserializedAPIresponse) Console.WriteLine(value, Color.Yellow);
        return APIresponse;
    }
}

