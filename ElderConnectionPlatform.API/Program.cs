using ElderConnectionPlatform.API;
using ElderConnectionPlatform.API.Middleware;
using Infracstructures;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddWebAPIService(builder);
builder.Services.AddInfractstructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elder Connection Platform");
});

app.UseCors("app-cors");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
