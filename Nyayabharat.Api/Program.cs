using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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

// PSEUDOCODE / PLAN (detailed):
// 1. Read JWT settings from configuration (Issuer, Audience, Key).
// 2. If Key is missing, use a short fallback but warn (ensure to set real secret in production).
// 3. Configure authentication with JwtBearer:
//    - RequireHttpsMetadata = true in Production, false otherwise.
//    - SaveToken = true.
//    - Set TokenValidationParameters to validate issuer, audience, lifetime and signing key.
// 4. Add Authorization services.
// 5. In the middleware pipeline call UseAuthentication() and UseAuthorization() before MapControllers().
// 6. Keep existing middlewares (exception logging and wrapper) so they can capture exceptions.
// 7. This avoids 500s caused by missing/incorrect authentication configuration in production.

// ---------------- Authentication ----------------

var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

// Fallback key to avoid null reference during startup — replace with real secret via configuration.
const string FallbackKey = "change_this_in_production_please_configure_a_strong_key";

var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(string.IsNullOrWhiteSpace(jwtKey) ? FallbackKey : jwtKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Require HTTPS in production for security
    options.RequireHttpsMetadata = builder.Environment.IsProduction();
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = !string.IsNullOrWhiteSpace(jwtIssuer),
        ValidIssuer = jwtIssuer,
        ValidateAudience = !string.IsNullOrWhiteSpace(jwtAudience),
        ValidAudience = jwtAudience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30)
    };

    // Optional: keep events minimal to avoid unhandled exceptions during authentication
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            // Let exception middleware handle/log the exception; do not throw from here.
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();

builder.Services.AddCorsPolicy();

/* ---------------- App ---------------- */

var app = builder.Build();

/* ---------------- Swagger ---------------- */

app.UseSwagger();
app.UseSwaggerUI();

/* ---------------- Middleware ---------------- */

// Exception middleware should wrap as early as possible to convert exceptions to responses
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ResponseWrapperMiddleware>();

app.UseCors("NyayabharatCors");

app.UseHttpsRedirection();

// Ensure authentication/authorization middleware are in pipeline before endpoint routing
app.UseAuthentication();
app.UseAuthorization();

/* ---------------- Endpoints ---------------- */

app.MapControllers();

app.Run();
