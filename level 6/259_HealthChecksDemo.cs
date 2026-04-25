using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    // 259. Health Checks UI Integration
    // In a distributed system, load balancers and orchestrators (like Kubernetes) 
    // need to know if your API is actually healthy, or if its database connection is broken.

    public class DatabaseHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // Simulate checking a database connection
            bool isDatabaseConnected = true;

            if (isDatabaseConnected)
                return Task.FromResult(HealthCheckResult.Healthy("Database is responding normally."));
            
            return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "Database connection failed."));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register Health Checks
            builder.Services.AddHealthChecks()
                   .AddCheck<DatabaseHealthCheck>("Core_SQL_Database");

            var app = builder.Build();

            // Map the health check to an endpoint
            app.MapHealthChecks("/api/health");

            Console.WriteLine("--- Health Checks Configured ---");
            Console.WriteLine("Load balancers can now ping '/api/health' to ensure the microservice is alive.");
            // app.Run();
        }
    }
}