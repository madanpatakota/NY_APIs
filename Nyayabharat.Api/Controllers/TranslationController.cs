using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/translations")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }


        //Endpoint to get translated text by entity type, entity id and language
        //http://https://localhost:7156/api/translations?entityType={entityType}&entityId={entityId}&lang={lang}
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string entityType,
            [FromQuery] int entityId,
            [FromQuery] string lang)
        {
            var text = await _translationService
                .GetTranslatedTextAsync(entityType, entityId, lang);

            if (text == null) return NotFound();
            return Ok(text);
        }
    }
}
