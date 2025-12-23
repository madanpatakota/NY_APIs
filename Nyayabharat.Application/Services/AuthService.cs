using Microsoft.Extensions.Configuration;
using Nyayabharat.Application.DTOs.Auth;
using Nyayabharat.Application.Helpers;
using Nyayabharat.Application.Interfaces.Repositories;
using Nyayabharat.Application.Interfaces.Services;
using Nyayabharat.Domain.Entities;
//using Nyayabharat.Infrastructure.Identity;

namespace Nyayabharat.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository userRepository,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        // REGISTER
        public async Task RegisterAsync(RegisterUserDto request)
        {
            var existing = await _userRepository.GetByUserNameAsync(request.UserName);
            if (existing != null)
                throw new Exception("User already exists");

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = PasswordHasher.Hash(request.Password),
                UserType = (Domain.Enums.UserType)request.UserType,
                CreatedOn = DateTime.UtcNow
            };


            await _userRepository.AddAsync(user);
        }

        // LOGIN
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);
            if (user == null)
                throw new Exception("Invalid credentials");

            if (!PasswordHasher.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var token = JwtHelper.GenerateToken(
                user.UserId,
                user.UserName,
                user.UserType.ToString(),
                _configuration["Jwt:Secret"]!
            );

            return new LoginResponseDto
            {
                UserName = user.UserName,
                UserType = user.UserType.ToString(),
                Token = token
            };
        }
    }
}
