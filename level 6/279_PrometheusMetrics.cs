using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace CloudNative
{
    // 279. Prometheus Metrics Export.
    // Exports real-time numbers (e.g., "Active Site Managers: 45") 
    // so monitoring tools can create live graphs.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Exposes the /metrics endpoint for Prometheus to scrape
            app.UseHttpMetrics();
            app.MapMetrics();

            app.MapGet("/api/site-data", () => "Data processed.");

            // app.Run();
        }
    }
}