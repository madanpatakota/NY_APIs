using Nyayabharat.Api.Extensions;
using Nyayabharat.Api.Filters;
using Nyayabharat.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<AuthorizationFilter>();
    options.Filters.Add<AuditLogFilter>();
});

//using Nyayabharat.Api.Middlewares;




bool jwtEnabled;

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddSwaggerDocumentation();

builder.Services.AddJwtAuthentication(builder.Configuration, out jwtEnabled);

if (jwtEnabled)
{
    builder.Services.AddAuthorizationPolicies();
}




builder.Services.AddCorsPolicy();
//builder.Services.AddJwtAuthentication(builder.Configuration);



var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ResponseWrapperMiddleware>();

app.UseCors("NyayabharatCors");


app.UseHttpsRedirection();
if (jwtEnabled)
{
    app.UseAuthentication();
    app.UseAuthorization();
}

app.MapControllers();

app.Run();
