using Microsoft.AspNetCore.Mvc;
using WealtherWalkingSkeleton.Models;
using WealtherWalkingSkeleton.Services;

namespace WealtherWalkingSkeleton.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOpenWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

     

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOpenWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet("GetWeatherForecast")]
        public IActionResult Get(string location, Unit unit = Unit.Imperial)
        {
            var forecast = _weatherService.GetFiveDayForecast(location, unit);
            return Ok(forecast);
        }
    }
}
