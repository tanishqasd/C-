using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. Setup Authorization Policies
builder.Services.AddAuthorization(options =>
{
    // Creating a specific rule: to access this policy, you MUST be an Admin
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

app.UseAuthorization();

// 2. Endpoints with Role Restrictions
app.MapGet("/api/dashboard", () => "Welcome to the Standard Dashboard.")
   .RequireAuthorization(); // Any logged-in user

app.MapGet("/api/admin-panel", () => "Welcome to the highly classified Admin Panel.")
   .RequireAuthorization("AdminOnly"); // ONLY users with the "Admin" role

app.Run();