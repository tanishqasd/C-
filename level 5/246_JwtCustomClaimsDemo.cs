using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace AdvancedCSharp
{
    // 246. JWT Custom Claims Validation
    // A JWT isn't just an access pass; it carries data ("Claims"). 
    // You can inject custom claims (like the specific construction site ID the user belongs to) 
    // and instruct the API to automatically validate them.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var key = Encoding.UTF8.GetBytes("SuperSecretKeyThatIsAtLeast32BytesLong!");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

            // Require the JWT to contain a specific custom claim
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeAssignedToSiteAlpha", policy => 
                    policy.RequireClaim("AssignedSiteId", "BLD-001"));
            });

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();

            // This endpoint will reject valid JWTs if they don't have the BLD-001 claim!
            app.MapGet("/api/site-alpha-vault", () => "Welcome to Site Alpha Data")
               .RequireAuthorization("MustBeAssignedToSiteAlpha");

            Console.WriteLine("--- JWT Custom Claims Policy Configured ---");
            // app.Run();
        }
    }
}