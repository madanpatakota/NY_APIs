using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Application.Services;

namespace Nyayabharat.Api.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/sections")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly ISectionLawService _sectionLawService; // 🔽 ADD

        public SectionController(
          ISectionService sectionService,
          ISectionLawService sectionLawService)   // 🔽 ADD
        {
            _sectionService = sectionService;
            _sectionLawService = sectionLawService; // 🔽 ADD
        }



        [Authorize]

        //Endpoint to get sections by act id http://https://localhost:7156/api/sections/by-act/{actId}
        [HttpGet("by-act/{actId}")]
        public async Task<IActionResult> GetByAct(int actId)
        {
            var sections = await _sectionService.GetByActIdAsync(actId);
            return Ok(sections);
        }


        [Authorize]
        //Endpoint to get section details by section id http://https://localhost:7156/api/sections/{sectionId}
        [HttpGet("{sectionId}")]
        public async Task<IActionResult> GetDetails(int sectionId)
        {
            var section = await _sectionService.GetWithDetailsAsync(sectionId);
            if (section == null) return NotFound();
            return Ok(section);
        }


        [HttpGet("{sectionId}/situations")]
        public async Task<IActionResult> GetSituationsBySection(int sectionId)
        {
            var result = await _sectionService.GetSituationsBySectionAsync(sectionId);
            return Ok(result);
        }


        // GET: api/sections/{sectionId}
        //// Get section details (content, subsections, clauses)
        //[HttpGet("{sectionId:int}")]
        //public async Task<IActionResult> GetById(int sectionId)
        //{
        //    var section = await _sectionService.GetWithDetailsAsync(sectionId);
        //    if (section == null)
        //        return NotFound(new { message = "Section not found" });

        //    return Ok(section);
        //}

        //// GET: api/sections/by-act/{actId}
        //// Get all sections under an Act
        //[HttpGet("by-act/{actId:int}")]
        //public async Task<IActionResult> GetByAct(int actId)
        //{
        //    var sections = await _sectionService.GetByActIdAsync(actId);
        //    return Ok(sections);

        // GET: api/sections/{id}/bns
        [HttpGet("{id:int}/bns")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBnsEquivalent(int id)
        {
            var result = await _sectionService.GetBnsEquivalentAsync(id);

            if (result == null)
                return NotFound(new { message = "No BNS mapping found for this IPC section" });

            if (result.MappingType == "Omitted")
            {
                return Ok(new
                {
                    ipcSectionId = result.IpcSectionId,
                    ipcSectionNumber = result.IpcSectionNumber,
                    status = "Omitted",
                    notes = result.Notes
                });
            }

            return Ok(result);
        }


        [HttpGet("{sectionId}/parallel")]
        public async Task<IActionResult> GetParallelSection(
    int sectionId,
    [FromQuery] string target)
        {
            if (string.IsNullOrWhiteSpace(target))
                return BadRequest("Target act is required (BNS / BNSS)");

            var result = await _sectionService
                .GetParallelSectionAsync(sectionId, target.ToUpper());

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet("by-chapter/{chapterId:int}")]
        public async Task<IActionResult> GetByChapter(int chapterId)
        {
            var sections = await _sectionService.GetByChapterIdAsync(chapterId);
            return Ok(sections);
        }



        //[HttpGet("{sectionId:int}")]
        //public async Task<IActionResult> GetSectionDetail(int sectionId)
        //{
        //    var result = await _sectionService.GetSectionDetailAsync(sectionId);

        //    if (result == null)
        //        return NotFound(new { message = "Section not found" });

        //    return Ok(result);
        //}


        [HttpGet("{sectionId:int}/content")]
        public async Task<IActionResult> GetSectionContent(int sectionId)
        {
            var result = await _sectionService.GetSectionContentAsync(sectionId);
            return Ok(result);
        }

        [HttpGet("{id}/judgments")]
        public async Task<IActionResult> GetJudgments(int id)
        {
            return Ok(await _sectionLawService.GetJudgments(id));
        }

        [HttpGet("{id}/appeal-rights")]
        public async Task<IActionResult> GetAppealRights(int id)
        {
            return Ok(await _sectionLawService.GetAppealRights(id));
        }

        [Authorize]
        [HttpPost("{id}/bookmark")]
        public async Task<IActionResult> Bookmark(int id)
        {
            int userId = int.Parse(User.FindFirst("UserId").Value);
            await _sectionLawService.BookmarkSection(userId, id);
            return Ok("Bookmarked");
        }


    }
}
