using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 236. CORS Policy Configuration for React
    // Cross-Origin Resource Sharing (CORS) is a browser security feature. 
    // If your React app runs on localhost:3000 and your API on localhost:5000, 
    // the browser blocks the connection unless the API explicitly allows it.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Define the CORS Policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactFrontendPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "https://construction-app.com")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials(); // Required if you are sending cookies/JWTs
                });
            });

            var app = builder.Build();

            // 2. Apply the middleware to the pipeline BEFORE authorization
            app.UseCors("ReactFrontendPolicy");

            app.MapGet("/api/site-status", () => new { Status = "Active", Workers = 142 });

            Console.WriteLine("--- CORS Policy Configured ---");
            // app.Run();
        }
    }
}