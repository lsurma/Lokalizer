using Lokalizer.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Lokalizer.Application.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Lokalizer.Host.AzFuncAPI.Controllers;

public class QueryController
{
    private readonly ILogger<QueryController> _logger;
    private readonly LokalizerDbContext _context;

    public QueryController(ILogger<QueryController> logger, LokalizerDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [Function("Query")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        
        var weatherForecasts = await _context.WeatherForecasts.ToListAsync();
        
        return new JsonResult(weatherForecasts);
    }

}