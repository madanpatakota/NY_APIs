using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{
    [ApiController]
    [Route("api/chapters")]
    public class ChaptersController : ControllerBase
    {
        private readonly IChapterService _chapterService;

        public ChaptersController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        // GET: api/chapters/by-act/1
        [HttpGet("by-act/{actId:int}")]
        public async Task<IActionResult> GetByAct(int actId)
        {
            var chapters = await _chapterService.GetByActIdAsync(actId);
            return Ok(chapters);
        }
    }
}
