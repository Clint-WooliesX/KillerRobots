using Microsoft.AspNetCore.Mvc;
using KillerRobots.Services;
using Newtonsoft.Json;

namespace KillerRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class Test_RejectionController : ControllerBase
{
    private readonly ILogger<Test_RejectionController> _logger;
    private readonly WebRequests _service;

    public Test_RejectionController(WebRequests service, ILogger<Test_RejectionController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost(Name = "Test_Rejection")]
    public async Task<object> Get(string LocationQuery, int NumberOfResults = 1)
    {
        string IPcheck = await _service.IPgeolocation();
        IPLocationCheck DeserializedIPCheck = new IPLocationCheck();
        DeserializedIPCheck = JsonConvert.DeserializeObject<IPLocationCheck>(IPcheck);

        if (DeserializedIPCheck.countryCode == "AU")
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
}

