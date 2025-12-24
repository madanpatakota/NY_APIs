using Nyayabharat.Api.Extensions;
using Nyayabharat.Api.Filters;
using Nyayabharat.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

/* -------------------- MVC -------------------- */

bool jwtEnabled;

builder.Services.AddControllers(options =>
{
    // Validation can always run
    options.Filters.Add<ValidationFilter>();

    // Auth-related filters ONLY if JWT is enabled
    if (builder.Configuration.GetSection("Jwt").Exists())
    {
        options.Filters.Add<AuthorizationFilter>();
        options.Filters.Add<AuditLogFilter>();
    }
});

/* -------------------- SERVICES -------------------- */

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddSwaggerDocumentation();

builder.Services.AddJwtAuthentication(builder.Configuration, out jwtEnabled);

if (jwtEnabled)
{
    builder.Services.AddAuthorizationPolicies();
}

builder.Services.AddCorsPolicy();

/* -------------------- APP -------------------- */

var app = builder.Build();
app.Logger.LogInformation("Nyayabharat API started successfully");


/* -------------------- SWAGGER -------------------- */

app.UseSwagger();
app.UseSwaggerUI();
app.Logger.LogInformation("Nyayabharat API started successfully-Next");


/* -------------------- MIDDLEWARE -------------------- */

// Custom middlewares (safe order)
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ResponseWrapperMiddleware>();


app.UseCors("NyayabharatCors");

app.UseHttpsRedirection();

/* -------------------- AUTH -------------------- */

if (jwtEnabled)
{
    app.UseAuthentication();
    app.UseAuthorization();
}

/* -------------------- ENDPOINTS -------------------- */

app.MapControllers();

app.Run();
