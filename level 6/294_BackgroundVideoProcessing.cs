using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace FinalIntegrations
{
    // 294. Background Video Processing Task.
    // When a drone uploads site footage, we shouldn't make the user wait. 
    // This background worker compresses and processes the video in the background.

    public class DroneVideoWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Logic: Check 'VideoQueue' table, process via FFmpeg, update DB
                await Task.Delay(10000, stoppingToken); 
            }
        }
    }
}