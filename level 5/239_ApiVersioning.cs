using Asp.Versioning; // Requires Asp.Versioning.Http NuGet
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 239. API Versioning Strategies
    // When you update your API, you cannot delete old endpoints because existing mobile 
    // apps will instantly crash. Versioning allows V1 and V2 to exist simultaneously.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Configure API Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true; // Tells the client what versions are available in the headers
                
                // Allow versioning via URL segment (e.g., /api/v1/...) or Header
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-API-Version"));
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            var app = builder.Build();

            // 2. Define Versioned Endpoints
            var versionSet = app.NewApiVersionSet()
                                .HasApiVersion(new ApiVersion(1, 0))
                                .HasApiVersion(new ApiVersion(2, 0))
                                .ReportApiVersions()
                                .Build();

            // V1: Legacy payroll return format
            app.MapGet("/api/v{version:apiVersion}/payroll", () => new { Total = 5000 })
               .WithApiVersionSet(versionSet)
               .MapToApiVersion(1, 0);

            // V2: New complex payroll return format
            app.MapGet("/api/v{version:apiVersion}/payroll", () => new { BasePay = 4000, Overtime = 1000, Total = 5000 })
               .WithApiVersionSet(versionSet)
               .MapToApiVersion(2, 0);

            Console.WriteLine("--- API Versioning Configured ---");
            // app.Run();
        }
    }
}