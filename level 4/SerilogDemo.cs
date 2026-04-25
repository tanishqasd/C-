using System;
using Serilog; // Requires Serilog.Sinks.Console NuGet package

class Program
{
    static void Main()
    {
        // Configure the logging pipeline
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        Log.Information("--- Serilog Demonstration Started ---");

        try
        {
            Log.Debug("Attempting to connect to external service...");
            PerformRiskyOperation();
        }
        catch (Exception ex)
        {
            // Logging the full exception trace cleanly
            Log.Error(ex, "A critical failure occurred during the operation.");
        }
        finally
        {
            Log.Information("--- Serilog Demonstration Ended ---");
            Log.CloseAndFlush(); // Always close the logger to free up file locks
        }
    }

    static void PerformRiskyOperation()
    {
        Log.Warning("Operation is running in an unoptimized state.");
        throw new InvalidOperationException("Simulated connection timeout.");
    }
}