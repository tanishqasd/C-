using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

// A Background Service runs continuously in the background, independent of web requests.
// Perfect for tasks like nightly payroll calculations or daily inventory reconciliation.
public class NightlyBatchWorker : BackgroundService
{
    private readonly ILogger<NightlyBatchWorker> _logger;

    public NightlyBatchWorker(ILogger<NightlyBatchWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Background worker started.");

        // Loop continuously until the application shuts down
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation($"[Worker] Running background job at: {DateTimeOffset.Now}");
            
            // Simulate heavy processing (e.g., aggregating daily site material logs)
            await Task.Delay(5000, stoppingToken); 
        }

        _logger.LogInformation("Background worker stopping.");
    }
}

// In your Program.cs, you would register it like this:
// builder.Services.AddHostedService<NightlyBatchWorker>();