using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;

namespace Nyayabharat.Api.Controllers
{
    [ApiController]
    [Route("api/acts")]
    [AllowAnonymous] // public read-only APIs
    public class ActController : ControllerBase
    {
        private readonly IActService _actService;
        private readonly ILogger<ActController> _logger;


        //ILogger is the logging service built into ASP.NET Core.Your code uses it to record messages such as “API request received,” warnings, or errors.

        public ActController(IActService actService, ILogger<ActController> logger)
        {
            _actService = actService;
            _logger = logger;
        }

        // GET: api/acts
        // Get all acts
        [HttpGet]
        public async Task<IActionResult> GetAllActs()
        {
            _logger.LogInformation("GetAllActs request received");
            var acts = await _actService.GetAllActsAsync();
            _logger.LogInformation("GetAllActs completed successfully");
            return Ok(acts);
        }

        // GET: api/acts/active
        // Get only active acts
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveActs()
        {
            _logger.LogInformation("GetActiveActs request received");
            var acts = await _actService.GetActiveActsAsync();
            _logger.LogInformation("GetActiveActs completed successfully");
            return Ok(acts);
        }

        // GET: api/acts/{id}
        // Get act details with chapters
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("GetActiveActs completed successfully");

            var act = await _actService.GetByIdAsync(id);
            if (act == null)
            {
                _logger.LogWarning("Act with ID {ActId} was not found", id);
                return NotFound(new { message = "Act not found" });
            }

            _logger.LogInformation("Act with ID {ActId} retrieved successfully", id);
            return Ok(act);
        }
    }
}
