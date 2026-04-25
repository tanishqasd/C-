using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AdvancedCSharp
{
    // 237. Minimal API Filters
    // Filters allow you to intercept a request just before it hits your endpoint.
    // This is perfect for validating headers, logging execution times, or standardizing inputs.

    public class SiteValidationFilter : IEndpointFilter
    {
        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            // Intercept: Check if the request contains the mandatory Site-ID header
            if (!context.HttpContext.Request.Headers.TryGetValue("X-Site-ID", out var siteId))
            {
                return Results.BadRequest("Missing mandatory X-Site-ID header.");
            }

            Console.WriteLine($"[Filter] Validated request for Site ID: {siteId}");

            // Proceed to the actual endpoint
            var result = await next(context);

            // You can also intercept the response here before it returns to the user!
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Apply the filter strictly to this endpoint
            app.MapPost("/api/inventory/update", (InventoryUpdate update) => 
            {
                return Results.Ok($"Inventory updated for item: {update.ItemName}");
            })
            .AddEndpointFilter<SiteValidationFilter>();

            Console.WriteLine("--- Minimal API Filters Configured ---");
            // app.Run();
        }
    }

    public record InventoryUpdate(string ItemName, int Quantity);
}