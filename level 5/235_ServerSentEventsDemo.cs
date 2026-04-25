using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AdvancedCSharp
{
    // 235. Server-Sent Events (SSE)
    // Unlike WebSockets (which are two-way), SSE is a ONE-WAY real-time connection. 
    // The server pushes continuous updates to the browser. 
    // It is significantly easier to set up than WebSockets and perfect for pushing live weather/safety alerts to the site.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/api/live-alerts", async context =>
            {
                // 1. Set the exact headers required for Server-Sent Events
                context.Response.Headers.Append("Content-Type", "text/event-stream");
                context.Response.Headers.Append("Cache-Control", "no-cache");
                context.Response.Headers.Append("Connection", "keep-alive");

                Console.WriteLine("--- Client Connected to SSE Stream ---");

                // 2. Stream data indefinitely
                for (int i = 1; i <= 5; i++)
                {
                    string alert = $"Safety Alert {i}: High wind speeds detected on crane level 4.";
                    
                    // SSE format strictly requires "data: " followed by the message and two newlines
                    await context.Response.WriteAsync($"data: {alert}\n\n");
                    await context.Response.Body.FlushAsync(); // Push it to the network immediately

                    await Task.Delay(3000); // Wait 3 seconds before next alert
                }
                
                await context.Response.WriteAsync("data: [STREAM_CLOSED]\n\n");
                await context.Response.Body.FlushAsync();
            });

            // app.Run();
        }
    }
}