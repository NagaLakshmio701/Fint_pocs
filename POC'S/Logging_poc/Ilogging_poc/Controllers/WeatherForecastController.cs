using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
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
            _logger.Log(LogLevel.Information, "HELLO WELCOME TO information LOGGING");
            _logger.Log(LogLevel.Trace, "HELLO WELCOME TO trace LOGGING");
            _logger.Log(LogLevel.Debug, "HELLO WELCOME TO LOGGING");
            _logger.Log(LogLevel.Error, "HELLO WELCOME TO LOGGING");
            _logger.Log(LogLevel.Warning, "HELLO WELCOME TO LOGGING");
            _logger.LogInformation("IT IS LOGINFORMATION_A0638");


            Console.WriteLine("uj");

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
    }
}
