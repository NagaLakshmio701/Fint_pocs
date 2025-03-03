using Microsoft.AspNetCore.Mvc;

namespace Serilog_poc.Controllers
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



            var operationId = Guid.NewGuid();
            using (_logger.BeginScope("OperationId: {OperationId}", operationId))
            {
                _logger.LogInformation("Starting the task with OperationId: {OperationId}", operationId);
                // Additional operations
                _logger.LogInformation("Task completed with OperationId: {OperationId}", operationId);

                _logger.LogError("Task ERROR with OperationId: {OperationId}", operationId);

                _logger.LogWarning("Task Warning with OperationId: {OperationId}", operationId);

                _logger.LogDebug("Task Debug with OperationId: {OperationId}", operationId);

                _logger.LogTrace("Task Trace with OperationId: {OperationId}", operationId);

                _logger.LogCritical("Task Critical with OperationId: {OperationId}", operationId);


            }

        }
    }
}
