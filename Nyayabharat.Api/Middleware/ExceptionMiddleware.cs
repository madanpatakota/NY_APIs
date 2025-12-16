using System.Net;
using System.Text.Json;
using Nyayabharat.Api.Models;
using Nyayabharat.Application.Common;

namespace Nyayabharat.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, ex.Message);
                await WriteError(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await WriteError(context, HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        private static async Task WriteError(
            HttpContext context,
            HttpStatusCode statusCode,
            string message)
        {
            var response = new ApiResponse<object>
            {
                Success = false,
                StatusCode = (int)statusCode,
                Message = message,
                Data = null,
                Errors = null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
