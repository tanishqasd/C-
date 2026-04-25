using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Azure Application Insights Telemetry
// This automatically tracks page load times, database query speeds, and exceptions 
// without needing to write custom tracking code everywhere.
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

app.MapGet("/api/diagnostics", (ILogger<Program> logger) =>
{
    // These logs automatically flow into the Application Insights cloud dashboard
    logger.LogInformation("Diagnostics endpoint was hit.");
    
    return "Application Insights is actively monitoring this API.";
});

app.Run();