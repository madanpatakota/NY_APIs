using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Nyayabharat.Infrastructure.Identity
{
    public class EntraTokenService
    {
        private readonly IConfiguration _configuration;

        public EntraTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateTokenAsync()
        {
            var tenantId = _configuration["AzureAd:TenantId"];
            var clientId = _configuration["AzureAd:ClientId"];
            var clientSecret = _configuration["AzureAd:ClientSecret"];

            var authority =
                $"https://login.microsoftonline.com/{tenantId}";

            var scope =
                $"api://{clientId}/.default";

            var app = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(authority)
                .Build();

            var result = await app
                .AcquireTokenForClient(new[] { scope })
                .ExecuteAsync();

            return result.AccessToken;
        }
    }
}