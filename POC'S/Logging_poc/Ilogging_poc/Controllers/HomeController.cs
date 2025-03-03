using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HomeController> _logger;
        private readonly TelemetryClient _telemetryClient;

        public HomeController(ILogger<HomeController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            _telemetryClient = telemetryClient;
        }

        [HttpGet(Name = "A0638_GetWeatherForecastFromHomeController")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Begin a logging scope for correlation
            using (_logger.BeginScope("RequestID: {RequestID}", Guid.NewGuid()))
            {
                _logger.LogInformation("Starting weather forecast generation in HomeController.");

                // Log telemetry event
                _telemetryClient.TrackEvent("_A0638_HOME_WeatherForecastRequested",
                    new Dictionary<string, string>
                    {
                        { "Controller", "HomeController" },
                        { "Method", "GET" }
                    });

                var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();

                _logger.LogInformation("Successfully generated weather forecast in HomeController.");

                return forecasts;
            }
        }
    }
}
