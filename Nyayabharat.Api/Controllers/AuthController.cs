using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyayabharat.Application.DTOs.Auth;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Endpoint: POST https://localhost:7156/api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto request)
        {
            await _authService.RegisterAsync(request);
            return Ok("User registered successfully");
        }

        // Endpoint: POST https://localhost:7156/api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }
    }
}
