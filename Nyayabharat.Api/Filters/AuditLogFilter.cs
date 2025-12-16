using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Nyayabharat.Api.Filters
{
    public class AuditLogFilter : IActionFilter
    {
        private readonly ILogger<AuditLogFilter> _logger;

        public AuditLogFilter(ILogger<AuditLogFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User.Identity?.Name ?? "Anonymous";
            var action = context.ActionDescriptor.DisplayName;

            _logger.LogInformation($"User {user} executing {action}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
