using Microsoft.AspNetCore.Authentication.JwtBearer;
using Nyayabharat.Api.Extensions;
using Nyayabharat.Api.Filters;
using Nyayabharat.Api.Middlewares;

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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});
//.AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//});




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
