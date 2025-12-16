namespace Nyayabharat.Application.Common
{
    public static class AppConstants
    {
        public const string JwtIssuer = "Nyayabharat";
        public const string JwtAudience = "NyayabharatUsers";
        public const int JwtExpiryMinutes = 60;

        public const string RoleAdmin = "Admin";
        public const string RoleCitizen = "Citizen";
        public const string RoleStudent = "Student";
        public const string RoleAspirant = "Aspirant";
        public const string RoleProfessional = "Professional";
    }
}
