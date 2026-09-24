using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Nyayabharat.Api.Extensions
{
    public static class AzureAdAuthenticationExtension
    {
        public static IServiceCollection AddAzureAdAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var tenantId = configuration["AzureAd:TenantId"];
            var clientId = configuration["AzureAd:ClientId"];
            var instance = configuration["AzureAd:Instance"];

            var authority = $"{instance}{tenantId}/v2.0";

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = authority;

                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidAudience = clientId,

                            ClockSkew = TimeSpan.Zero
                        };
                });

            return services;
        }
    }
}