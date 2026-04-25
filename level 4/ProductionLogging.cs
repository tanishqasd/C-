using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;

// Production logging isn't just writing text to a file; it's "Structured Logging" 
// where data is saved as searchable JSON objects, often sent to ElasticSearch or Datadog.

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // Ignore spammy system logs
    .Enrich.FromLogContext()
    .Enrich.WithMachineName() // Adds the server ID to every log automatically
    .Enrich.WithEnvironmentName()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}")
    .WriteTo.File("logs/enterprise-log.json", formatting: new Serilog.Formatting.Json.JsonFormatter())
    .CreateLogger();

try
{
    Log.Information("Starting enterprise host...");
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(); // Tell the app to use our Serilog setup
    
    var app = builder.Build();

    app.MapGet("/api/process", () =>
    {
        // Structured Logging: Instead of concatenating strings, we pass variables.
        // A log server can now filter all logs where Action = "MaterialAudit"
        Log.Information("Processing {Action} for Site {SiteId}", "MaterialAudit", 104);
        return "Audit complete.";
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}