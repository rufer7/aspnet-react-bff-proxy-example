using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactBffProxy.Server.Controllers;

[ApiController]
[Authorize]
[ValidateAntiForgeryToken]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] _summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
        _logger.LogDebug("Get weather forecasts");
#pragma warning restore CA1848 // Use the LoggerMessage delegates

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    [Authorize]
    public void Post()
    {
        Debug.WriteLine("Post received!");
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

