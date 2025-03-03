using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    public class Simple_Logging_Controller : Controller
    {

        private readonly ILogger<Simple_Logging_Controller> _logger;

        public Simple_Logging_Controller(ILogger<Simple_Logging_Controller> logger)
        {
            _logger = logger;
        }

        // 1. Trace Example
        [HttpGet("trace_638")]
        public IActionResult TraceExample_638()
        {
            _logger.LogTrace("Trace: Detailed information about the app's flow.");
            return Ok("Trace log sent.");
        }

        // 2. Debug Example
        [HttpGet("debug_638")]
        public IActionResult DebugExample_638()
        {
            _logger.LogDebug("Debug: Diagnostic information useful for debugging.");
            return Ok("Debug log sent.");
        }

        // 3. Information Example
        [HttpGet("info_638")]
        public IActionResult InfoExample_638()
        {
            _logger.LogInformation("Information: General application events like milestones.");
            return Ok("Information log sent.");
        }

        // 4. Warning Example
        [HttpGet("warning_638")]
        public IActionResult WarningExample_638()
        {
            _logger.LogWarning("Warning: Potential issues that need attention.");
            return Ok("Warning log sent.");
        }

        // 5. Error Example
        [HttpGet("error_638")]
        public IActionResult ErrorExample_638()
        {
            try
            {
                throw new Exception("Simulated exception for Error log.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: An exception occurred.");
                return StatusCode(500, "Error log sent.");
            }
        }

        // 6. Critical Example
        [HttpGet("critical_638")]
        public IActionResult CriticalExample_638()
        {
            _logger.LogCritical("Critical: A severe failure causing system instability.");
            return StatusCode(500, "Critical log sent.");
        }
    }
}
