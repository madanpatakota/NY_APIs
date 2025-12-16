using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Nyayabharat.Application.Common;

namespace Nyayabharat.Application.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateToken(
            int userId,
            string userName,
            string userType,
            string secretKey)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim(ClaimTypes.Role, userType)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: AppConstants.JwtIssuer,
                audience: AppConstants.JwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(AppConstants.JwtExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
