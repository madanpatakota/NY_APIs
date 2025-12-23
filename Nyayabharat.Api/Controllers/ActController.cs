using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/acts")]
    public class ActController : ControllerBase
    {
        private readonly IActService _actService;

        public ActController(IActService actService)
        {
            _actService = actService;
        }




        //Endpoint to get all acts http://https://localhost:7156/api/acts

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var acts = await _actService.GetAllAsync();
            return Ok(acts);
        }



        //Endpoint to get all active acts http://https://localhost:7156/api/acts/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var acts = await _actService.GetActiveAsync();
            return Ok(acts);
        }


        //Endpoint to get act by id http://https://localhost:7156/api/acts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var act = await _actService.GetByIdAsync(id);
            if (act == null) return NotFound();
            return Ok(act);
        }
    }
}
