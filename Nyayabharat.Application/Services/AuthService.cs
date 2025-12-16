using Microsoft.Extensions.Configuration;
using Nyayabharat.Application.DTOs.Auth;
using Nyayabharat.Application.Helpers;
using Nyayabharat.Application.Interfaces.Services;

namespace Nyayabharat.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            // NOTE: Real user validation will come after UserRepository
            var token = JwtHelper.GenerateToken(
                userId: 1,
                userName: request.UserName,
                userType: "Citizen",
                secretKey: _configuration["Jwt:Secret"]!
            );

            var response = new LoginResponseDto
            {
                UserName = request.UserName,
                UserType = "Citizen",
                Token = token
            };

            return Task.FromResult(response);
        }
    }
}
