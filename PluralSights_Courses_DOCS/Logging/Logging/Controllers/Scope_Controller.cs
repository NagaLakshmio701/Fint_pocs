using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Scope_Controller : Controller
    {
        private readonly TelemetryClient _telemetryClient;
        private readonly ILogger<Scope_Controller> _logger;

        public Scope_Controller(TelemetryClient telemetryClient, ILogger<Scope_Controller> logger)
        {
            _telemetryClient = telemetryClient;
            _logger = logger;
        }

        // 1. Basic Scope
        [HttpGet("basic-scope")]
        public IActionResult BasicScope_A0638()
        {
            using (_logger.BeginScope("OperationID: {OperationId}", Guid.NewGuid()))
            {
                _logger.LogInformation("Log message inside a basic scope.");
                _telemetryClient.TrackTrace("Basic Scope Trace", SeverityLevel.Information);
            }

            return Ok("Basic scope logged.");
        }

        // 2. Dictionary Scope
        [HttpGet("dictionary-scope")]
        public IActionResult DictionaryScope_638()
        {
            using (_logger.BeginScope(new Dictionary<string, object>
            {
                { "UserId", Guid.NewGuid() },
                { "Role", "Admin" },
                { "Action", "Login" }
            }))
            {
                _logger.LogInformation("Log message with dictionary scope.");
                _telemetryClient.TrackEvent("Dictionary Scope Event", new Dictionary<string, string>
                {
                    { "UserId", "SampleUserId" },
                    { "Role", "Admin" },
                    {"Name","NagaLakshmi" },
                    {"EmpID","A0638" },
                    { "Action", "Login" }
                });
            }

            return Ok("Dictionary scope logged.");
        }

        // 3. Nested Scopes
        [HttpGet("nested-scope")]
        public IActionResult NestedScope_638()
        {
            using (_logger.BeginScope("OuterScope: {OuterScopeId}", Guid.NewGuid()))
            {
                _logger.LogInformation("Log message in the outer scope.");

                using (_logger.BeginScope("InnerScope: {InnerScopeId}", Guid.NewGuid()))
                {
                    _logger.LogInformation("Log message in the inner scope.");
                    _telemetryClient.TrackTrace("Nested Scope Trace", SeverityLevel.Information);
                }
            }

            return Ok("Nested scopes logged.");


        }




    }
}
