using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{
    [ApiController]
    [Route("api/acts")]
    [AllowAnonymous] // public read-only APIs
    public class ActController : ControllerBase
    {
        private readonly IActService _actService;

        public ActController(IActService actService)
        {
            _actService = actService;
        }

        // GET: api/acts
        // Get all acts
        [HttpGet]
        public async Task<IActionResult> GetAllActs()
        {
            var acts = await _actService.GetAllActsAsync();
            return Ok(acts);
        }

        // GET: api/acts/active
        // Get only active acts
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveActs()
        {
            var acts = await _actService.GetActiveActsAsync();
            return Ok(acts);
        }

        // GET: api/acts/{id}
        // Get act details with chapters
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var act = await _actService.GetByIdAsync(id);
            if (act == null)
                return NotFound(new { message = "Act not found" });

            return Ok(act);
        }
    }
}
