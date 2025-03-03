using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace Telemetry_ApplicationInsights_poc.Controllers
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
        private readonly TelemetryClient _telemetryClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            _telemetryClient = telemetryClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Begin a logging scope
            using (_logger.BeginScope("WeatherForecastRequest: {RequestId}", Guid.NewGuid()))
            {
                try
                {
                    _logger.LogInformation("Start generating weather forecast");

                    // Log a custom event using Application Insights
                    _telemetryClient.TrackEvent("WeatherForecastRequested",
                        new Dictionary<string, string>
                        {
                            { "Controller", "WeatherForecast" },
                            { "Method", "GET" },
                            { "RequestID",Guid.NewGuid().ToString() }
                        });

                    var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    }).ToArray();

                    _logger.LogInformation("Successfully generated weather forecast");

                    return forecasts;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while generating weather forecast");
                    throw;
                }
                finally
                {
                    _logger.LogInformation("Completed weather forecast request");
                }
            }
        }
    }
}
