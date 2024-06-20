using ElderConnectionPlatform.API;
using ElderConnectionPlatform.API.Middleware;
using Infracstructures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = string.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.development.json");
    connection = builder.Configuration.GetConnectionString("azure_sql_connectionstring");
}
else
{
    connection = Environment.GetEnvironmentVariable("azure_sql_connectionstring");
}
//config sqlazure
//builder.Services.AddDbContext<ElderConnectionContext>(options =>
//        options.UseSqlServer(connection));


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
