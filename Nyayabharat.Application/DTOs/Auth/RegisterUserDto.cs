namespace Nyayabharat.Application.DTOs.Auth
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }   // 0=Guest,1=Citizen,2=Admin

        public string Password { get; set; } = null!;
    }
}

