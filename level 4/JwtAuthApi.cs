using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure JWT Authentication Services
var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKeyThatIsAtLeast32BytesLong!"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// 2. Enable the Authentication Middleware
app.UseAuthentication();
app.UseAuthorization();

// 3. Endpoints
// Public endpoint - anyone can access
app.MapGet("/api/public", () => "This is public data.");

// Protected endpoint - requires a valid JWT token
app.MapGet("/api/secure", () => "You have a valid token! Here is the secure data.")
   .RequireAuthorization();

app.Run();