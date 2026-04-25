using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure Rate Limiting Policies
builder.Services.AddRateLimiter(options =>
{
    // Creating a policy named "fixed" that only allows 3 requests every 10 seconds
    options.AddFixedWindowLimiter("fixed", policy =>
    {
        policy.PermitLimit = 3;
        policy.Window = TimeSpan.FromSeconds(10);
        policy.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        policy.QueueLimit = 0; // Don't queue requests, just reject them immediately
    });

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

var app = builder.Build();

// 2. Enable the Rate Limiting Middleware
app.UseRateLimiter();

// 3. Apply the policy to an endpoint
app.MapGet("/api/limited", () => "Success! You have not exceeded your rate limit yet.")
   .RequireRateLimiting("fixed");

app.Run();