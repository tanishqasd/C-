using OpenTelemetry.Trace;
using Microsoft.Extensions.DependencyInjection;

namespace CloudNative
{
    // 278. OpenTelemetry Tracing.
    // In a microservice world, one request might touch 5 different servers. 
    // Tracing allows you to see the "path" of a request across all services.

    class Program
    {
        static void ConfigureTracing(IServiceCollection services)
        {
            services.AddOpenTelemetry()
                .WithTracing(builder => builder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddSqlClientInstrumentation()
                    .AddConsoleExporter()); // Sends traces to the log for debugging
        }
    }
}