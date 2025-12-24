using Nyayabharat.Api.Extensions;
using Nyayabharat.Api.Middlewares;
using Nyayabharat.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

/* ---------------- Controllers ---------------- */

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

/* ---------------- Services ---------------- */

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddSwaggerDocumentation();

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
    });


builder.Services.AddCorsPolicy();


//builder.Services.AddCorsPolicy();

/* ---------------- App ---------------- */

var app = builder.Build();

/* ---------------- Swagger ---------------- */

app.UseSwagger();
app.UseSwaggerUI();

/* ---------------- Middleware ---------------- */

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ResponseWrapperMiddleware>();

app.UseCors("NyayabharatCors");

app.UseHttpsRedirection();

/* ---------------- Endpoints ---------------- */

app.MapControllers();

app.Run();
