using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 240. Antiforgery Tokens (CSRF Protection)
    // Cross-Site Request Forgery (CSRF) is an attack where a malicious website tricks 
    // a user's browser into making an unwanted action on your API. 
    // Antiforgery tokens cryptographically verify that the request intentionally came from your frontend.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Add Antiforgery Services
            builder.Services.AddAntiforgery(options => 
            {
                options.HeaderName = "X-CSRF-TOKEN"; // The header the React app must send back
            });

            var app = builder.Build();

            // 2. Enable the middleware
            app.UseAntiforgery();

            // 3. Endpoint to distribute the token to the frontend (e.g., upon login)
            app.MapGet("/api/security/get-token", (HttpContext context, Microsoft.AspNetCore.Antiforgery.IAntiforgery antiforgery) =>
            {
                var token = antiforgery.GetAndStoreTokens(context);
                return Results.Ok(new { CSRFToken = token.RequestToken });
            });

            // 4. Secure the critical action
            app.MapPost("/api/finance/wire-transfer", () => Results.Ok("Funds transferred securely."))
               .RequireAntiforgery(); // Fails with 400 Bad Request if the token is missing or invalid

            Console.WriteLine("--- CSRF Protection Enabled ---");
            // app.Run();
        }
    }
}