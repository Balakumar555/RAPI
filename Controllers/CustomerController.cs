using Microsoft.AspNetCore.Mvc;
using RAPI;
namespace RAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppLogger _logger;

        public CustomerController(AppLogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("Processing GET request for CustomerController");

                // Simulate some work
                var result = "Hello from CustomerController!";

                _logger.LogInformation("Successfully processed GET request");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing GET request");
                return StatusCode(500, "An error occurred");
            }
        }
    }
}