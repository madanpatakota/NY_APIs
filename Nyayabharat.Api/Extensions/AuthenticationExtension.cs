using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Nyayabharat.Api.Extensions
{
    public static class AuthenticationExtension
    {

        public static IServiceCollection AddJwtAuthentication(
    this IServiceCollection services,
    IConfiguration configuration)
        {
            var secret = configuration["Jwt:Secret"];
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];

            // SAFETY CHECK (do NOT throw)
            if (string.IsNullOrWhiteSpace(secret) ||
                string.IsNullOrWhiteSpace(issuer) ||
                string.IsNullOrWhiteSpace(audience))
            {
                // JWT not configured → skip auth
                return services;
            }

            var key = Encoding.UTF8.GetBytes(secret);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; // Azure-safe
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }


        //public static IServiceCollection AddJwtAuthentication(
        //    this IServiceCollection services,
        //    IConfiguration configuration)
        //{
        //   // var key = Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!);


        //    var secret = configuration["Jwt:Secret"];

        //    if (string.IsNullOrEmpty(secret))
        //    {
        //        throw new Exception("JWT Secret is missing from configuration");
        //    }

        //    var key = Encoding.UTF8.GetBytes(secret);


        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options =>
        //        {
        //            options.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuer = true,
        //                ValidateAudience = true,
        //                ValidateLifetime = true,
        //                ValidateIssuerSigningKey = true,
        //                ValidIssuer = configuration["Jwt:Issuer"],
        //                ValidAudience = configuration["Jwt:Audience"],
        //                IssuerSigningKey = new SymmetricSecurityKey(key)
        //            };
        //        });

        //    return services;
        //}
    }
}
