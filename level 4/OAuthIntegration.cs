using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure Authentication Services to use Google OAuth
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(googleOptions =>
{
    // In production, these should be loaded securely from Azure Key Vault
    googleOptions.ClientId = "your-google-client-id";
    googleOptions.ClientSecret = "your-google-client-secret";
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// 2. Protected endpoint that forces user to login via Google
app.MapGet("/secure-data", () => "You are logged in via Google!")
   .RequireAuthorization();

app.Run();