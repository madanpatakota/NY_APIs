using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Application.Services;
using Nyayabharat.Domain.Enums;

namespace Nyayabharat.Api.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/situations")]
    public class SituationController : ControllerBase
    {
        private readonly ISituationService _situationService;

        private readonly ISituationLawService _situationLawService;

        public SituationController(
            ISituationService situationService,
            ISituationLawService situationLawService)
        {
            _situationService = situationService;
            _situationLawService = situationLawService;
        }


        [Authorize]
        //Endpoint to get law by situation id http://https://localhost:7156/api/situations/{id}/law
        [HttpGet("{id}/law")]
        public async Task<IActionResult> GetLaw(int id)
        {
            var result = await _situationLawService.GetLawBySituationAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [Authorize]
        //Endpoint to get all situations http://https://localhost:7156/api/situations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var situations = await _situationService.GetAllAsync();
            return Ok(situations);
        }

        [Authorize]
        //Endpoint to get situations by severity http://https://localhost:7156/api/situations/severity/{severity}
        [HttpGet("severity/{severity}")]
        public async Task<IActionResult> GetBySeverity(SeverityLevel severity)
        {
            var situations = await _situationService.GetBySeverityAsync(severity);
            return Ok(situations);
        }

        [Authorize]
        //Endpoint to get situation by id http://https://localhost:7156/api/situations/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var situation = await _situationService.GetByIdAsync(id);
            if (situation == null) return NotFound();
            return Ok(situation);
        }
    }
}
