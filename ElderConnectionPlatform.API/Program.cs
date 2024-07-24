using ElderConnectionPlatform.API;
using ElderConnectionPlatform.API.Middleware;
using Infracstructures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Configuration
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
}
else
{
    builder.Configuration.AddEnvironmentVariables();
}

// Retrieve the connection string
var connection = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("azure_sql_connectionstring") + ";Connection Timeout=30;MultipleActiveResultSets=true;"
    : Environment.GetEnvironmentVariable("azure_sql_connectionstring") + ";Connection Timeout=30;MultipleActiveResultSets=true;";

// Ensure the connection string is not null or empty
if (string.IsNullOrEmpty(connection))
{
    throw new InvalidOperationException("No connection string found.");
}

// Configure SQL Server with retry options
//builder.Services.AddDbContext<ElderConnectionContext>(options =>
//    options.UseSqlServer(connection, sqlOptions =>
//    {
//        sqlOptions.EnableRetryOnFailure(
//            maxRetryCount: 3,
//            maxRetryDelay: TimeSpan.FromSeconds(3),
//            errorNumbersToAdd: null);
//    }));


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
