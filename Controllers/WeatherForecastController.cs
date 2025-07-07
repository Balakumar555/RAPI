using Microsoft.AspNetCore.Mvc;

namespace RAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet]
    [Route("Get/{custId}")]
    public IActionResult Get(int custId)
    {
        var customer = new { Id = custId, Name = "Balakumar" };
        return Ok(customer);
    }

    [HttpGet]
    [Route("Get/{empId}")]
    public IActionResult Get(string empId)
    {
        var employee = new { Id = empId, Name = "RajKumar" };
        return Ok(employee);
    }
}
