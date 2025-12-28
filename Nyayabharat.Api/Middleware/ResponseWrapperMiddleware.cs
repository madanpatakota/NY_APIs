using Nyayabharat.Api.Models;
using System.Text;
using System.Text.Json;

namespace Nyayabharat.Api.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Skip wrapping for swagger & non-api requests
            if (!context.Request.Path.StartsWithSegments("/api"))
            {
                await _next(context);
                return;
            }

            var originalBodyStream = context.Response.Body;

            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            try
            {
                await _next(context);

                // Do not wrap for no-content responses
                if (context.Response.StatusCode == StatusCodes.Status204NoContent)
                {
                    context.Response.Body = originalBodyStream;
                    return;
                }

                // Only wrap JSON responses
                var contentType = context.Response.ContentType;
                if (contentType == null || !contentType.Contains("application/json"))
                {
                    context.Response.Body = originalBodyStream;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalBodyStream);
                    return;
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                var bodyText = await new StreamReader(memoryStream).ReadToEndAsync();

                object? bodyData = null;

                if (!string.IsNullOrWhiteSpace(bodyText))
                {
                    bodyData = JsonSerializer.Deserialize<object>(bodyText);
                }

                var response = new ApiResponse<object>
                {
                    Success = context.Response.StatusCode < 400,
                    Data = bodyData,
                    Message = context.Response.StatusCode < 400 ? null : "Request failed",
                    Timestamp = DateTime.UtcNow
                };

                var json = JsonSerializer.Serialize(response);


                context.Response.Body = originalBodyStream;
                context.Response.ContentLength = Encoding.UTF8.GetByteCount(json);

                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                // Restore body stream before rethrow
                context.Response.Body = originalBodyStream;
                throw;
            }
        }
    }
}


//public class ApiResponse<T>
//{
//    public bool Success { get; set; }
//    public T? Data { get; set; }
//    public string? Message { get; set; }
//    public DateTime Timestamp { get; set; }
//}
