using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Infrastructure.Identity;

namespace Nyayabharat.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly EntraTokenService _tokenService;

        public TokenController(EntraTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            try
            {
                var token = await _tokenService.GenerateTokenAsync();

                return Ok(new
                {
                    access_token = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
        }
    }
}