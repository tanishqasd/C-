using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace AdvancedCSharp
{
    // 247. OAuth2 Authorization Code Flow
    // Instead of forcing workers to create a new password, you allow them to log in 
    // using their enterprise Microsoft or Google accounts. This utilizes the standard OAuth2 Flow.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "CustomOAuth"; // Trigger OAuth redirect
            })
            .AddCookie()
            .AddOAuth("CustomOAuth", options =>
            {
                // In production, these come from Azure Key Vault
                options.ClientId = "your-client-id";
                options.ClientSecret = "your-client-secret";
                options.CallbackPath = "/oauth/callback";
                options.AuthorizationEndpoint = "https://provider.com/oauth/authorize";
                options.TokenEndpoint = "https://provider.com/oauth/token";
                options.UserInformationEndpoint = "https://provider.com/api/userinfo";

                // Mapping the provider's data to our internal .NET Claims
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
            });

            var app = builder.Build();

            app.UseAuthentication();
            
            // Trigger the login flow
            app.MapGet("/login", () => Results.Challenge(new Microsoft.AspNetCore.Authentication.AuthenticationProperties { RedirectUri = "/" }, new[] { "CustomOAuth" }));

            Console.WriteLine("--- OAuth2 Flow Configured ---");
            // app.Run();
        }
    }
}