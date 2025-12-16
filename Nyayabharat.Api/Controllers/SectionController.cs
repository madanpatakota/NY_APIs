using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }



        //Endpoint to get sections by act id http://https://localhost:7156/api/sections/by-act/{actId}
        [HttpGet("by-act/{actId}")]
        public async Task<IActionResult> GetByAct(int actId)
        {
            var sections = await _sectionService.GetByActIdAsync(actId);
            return Ok(sections);
        }


        //Endpoint to get section details by section id http://https://localhost:7156/api/sections/{sectionId}
        [HttpGet("{sectionId}")]
        public async Task<IActionResult> GetDetails(int sectionId)
        {
            var section = await _sectionService.GetWithDetailsAsync(sectionId);
            if (section == null) return NotFound();
            return Ok(section);
        }
    }
}
