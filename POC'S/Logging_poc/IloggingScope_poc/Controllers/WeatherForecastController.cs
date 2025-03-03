using Microsoft.AspNetCore.Mvc;

namespace IloggingScope_poc.Controllers
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

        [HttpGet("task")]
        public void PerformTask()
        {
            // Define a scope with additional metadata
            var operationId = Guid.NewGuid();

            // Start a scope that automatically adds 'OperationId' to every log entry within this scope
            using (_logger.BeginScope("OperationId: {OperationId}", operationId))
            {
                _logger.LogInformation("Starting the task with OperationId: {OperationId}", operationId);
                // Additional operations
                _logger.LogInformation("Task completed.");

                _logger.LogError("Task encountered an error.");
                _logger.LogWarning("Task warning issued.");
                _logger.LogDebug("Debugging the task.");
                _logger.LogTrace("Tracing the task.");
                _logger.LogCritical("Task Critical error.");
            }
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
