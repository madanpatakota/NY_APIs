using Nyayabharat.Application.DTOs.Auth;

namespace Nyayabharat.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task RegisterAsync(RegisterUserDto request);
    }

}
