using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CloudNative
{
    // 277. Kubernetes Probes in ASP.NET Core.
    // Kubernetes needs to know if your app is "Ready" to take traffic 
    // or if it has crashed and needs to be restarted ("Liveness").

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHealthChecks(); // Required for K8s probes

            var app = builder.Build();

            app.MapHealthChecks("/health/liveness"); // K8s check: Is the process alive?
            app.MapHealthChecks("/health/readiness"); // K8s check: Is the DB ready?

            // app.Run();
        }
    }
}