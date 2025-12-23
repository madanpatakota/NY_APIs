using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Nyayabharat.Api.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // 🔑 Skip authorization if AllowAnonymous is present
            var hasAllowAnonymous =
                context.ActionDescriptor.EndpointMetadata
                       .Any(em => em is AllowAnonymousAttribute);

            if (hasAllowAnonymous)
                return;

            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? true)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
