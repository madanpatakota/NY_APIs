using Microsoft.Extensions.DependencyInjection;

namespace Nyayabharat.Api.Extensions
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("CitizenAccess", policy =>
                    policy.RequireRole("Citizen", "Student", "Aspirant", "Professional"));
            });

            return services;
        }
    }
}
