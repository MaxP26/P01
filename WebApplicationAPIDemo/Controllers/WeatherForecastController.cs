using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplicationAPIDemo.Services;
//  https://www.google.com/api/v0
// POST
// GET
// PUT
// DELETE

namespace WebApplicationAPIDemo.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TimeService _timeService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,TimeService date)
        {
            _logger = logger;
            _timeService = date;

        }

        [HttpDelete]

        public Task DeleteAsync()
        {
            return Task.CompletedTask;
        }

        [HttpGet()]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("StartTime")]
        public DateTime GetSatrtTime()
        {
            return _timeService.StartTime;
        }

        [HttpGet("Calc")]
        public Double Calc([FromQuery] double a, [FromQuery] double b)
        {
            //Request.Body
            return a +b;
        }

    
    }
}