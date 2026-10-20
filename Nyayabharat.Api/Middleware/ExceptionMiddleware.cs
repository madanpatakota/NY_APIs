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

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
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
                _logger.LogWarning(
                    ex,
                    "Application error for {Method} {Path}",
                    context.Request.Method,
                    context.Request.Path);

                await WriteError(
                    context,
                    HttpStatusCode.BadRequest,
                    ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Unhandled error for {Method} {Path}",
                    context.Request.Method,
                    context.Request.Path);

                await WriteError(
                    context,
                    HttpStatusCode.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        private static async Task WriteError(
            HttpContext context,
            HttpStatusCode statusCode,
            string message)
        {
            if (context.Response.HasStarted)
            {
                return;
            }

            context.Response.Clear();
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<object>
            {
                Success = false,
                StatusCode = (int)statusCode,
                Message = message,
                Data = null,
                Errors = null
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}