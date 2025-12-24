using System.Text.Json;
using Nyayabharat.Api.Models;

namespace Nyayabharat.Api.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBody = context.Response.Body;

            using var memStream = new MemoryStream();
            context.Response.Body = memStream;

            await _next(context);

            memStream.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(memStream).ReadToEndAsync();

            context.Response.Body = originalBody;

            // Do not wrap Swagger or empty responses
            if (context.Request.Path.StartsWithSegments("/swagger") ||
                string.IsNullOrWhiteSpace(bodyText))
            {
                await context.Response.WriteAsync(bodyText);
                return;
            }

            object? data;
            try
            {
                data = JsonSerializer.Deserialize<object>(bodyText);
            }
            catch
            {
                data = bodyText;
            }

            var response = new ApiResponse<object>
            {
                Success = context.Response.StatusCode < 400,
                StatusCode = context.Response.StatusCode,
                Message = context.Response.StatusCode < 400
                    ? "Request successful"
                    : "Request failed",
                Data = context.Response.StatusCode < 400 ? data : null,
                Errors = context.Response.StatusCode >= 400 ? data : null
            };

            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
