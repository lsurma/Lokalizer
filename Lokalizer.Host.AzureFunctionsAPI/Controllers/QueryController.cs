using Lokalizer.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Lokalizer.Host.AzureFunctionsAPI.Controllers;

public class QueryController
{
    private readonly ILogger<QueryController> _logger;

    public QueryController(ILogger<QueryController> logger)
    {
        _logger = logger;
    }

    [Function("Query")]
    public IActionResult Query([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new JsonResult(new List<WeatherForecast>()
        {
            new(),
            new(),
            new(),
            new(),
            new()
        });
    }

}