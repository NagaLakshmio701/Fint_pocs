using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    public class TelemetryClient_Logging_Controller : Controller
    {
        private readonly TelemetryClient _telemetryClient;

        public TelemetryClient_Logging_Controller(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        [HttpGet("trace")]
        public IActionResult LogTrace_638()
        {
            _telemetryClient.TrackTrace("This is a Trace log", SeverityLevel.Information,
                new Dictionary<string, string> { { "Key", "Value" }, { "Operation", "LogTrace" } });
            return Ok("Trace log sent to Application Insights.");
        }

        [HttpGet("event")]
        public IActionResult LogEvent_638()
        {
            _telemetryClient.TrackEvent("Custom Event Example",
                new Dictionary<string, string> { { "Category", "Example" }, { "Action", "LogEvent" } });
            return Ok("Custom event sent to Application Insights.");
        }

        [HttpGet("metric")]
        public IActionResult LogMetric_638()
        {
            _telemetryClient.TrackMetric("Custom Metric Example", 123);
            return Ok("Metric sent to Application Insights.");
        }

        [HttpGet("exception")]
        public IActionResult LogException_638()
        {
            try
            {
                throw new InvalidOperationException("This is a custom exception for demonstration.");
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex,
                    new Dictionary<string, string> { { "Handled", "True" }, { "Operation", "LogException" } });
                return Ok("Exception logged to Application Insights.");
            }
        }

        [HttpGet("dependency")]
        public IActionResult LogDependency_638()
        {
            var dependencyTelemetry = new DependencyTelemetry
            {
                Name = "SQL Dependency",
                Target = "SQL Server",
                Data = "SELECT * FROM Users",
                Type = "SQL",
                Duration = TimeSpan.FromMilliseconds(100),
                Success = true
            };
            _telemetryClient.TrackDependency(dependencyTelemetry);
            return Ok("Dependency logged to Application Insights.");
        }

        [HttpGet("request")]
        public IActionResult LogRequest_638()
        {
            var requestTelemetry = new RequestTelemetry
            {
                Name = "GET /TelemetryLoggingController/request",
                Timestamp = DateTimeOffset.UtcNow,
                Duration = TimeSpan.FromMilliseconds(150),
                ResponseCode = "200",
                Success = true
            };
            _telemetryClient.TrackRequest(requestTelemetry);
            return Ok("Request logged to Application Insights.");
        }
    }
}

