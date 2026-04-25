using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

// In a Multi-Tenant application, a single instance of the software serves multiple 
// distinct client organizations (tenants), keeping their data strictly isolated.
public class TenantIdentificationMiddleware
{
    private readonly RequestDelegate _next;

    public TenantIdentificationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Identify the tenant using a custom HTTP Header
        var tenantId = context.Request.Headers["X-Tenant-ID"].ToString();

        if (string.IsNullOrEmpty(tenantId))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Missing X-Tenant-ID header. Cannot route request.");
            return;
        }

        // Store the identified tenant in the context items so downstream logic can use it
        context.Items["TenantId"] = tenantId;
        Console.WriteLine($"[Routing] Processing request for Tenant: {tenantId}");

        await _next(context);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Register the middleware
        app.UseMiddleware<TenantIdentificationMiddleware>();

        app.MapGet("/api/dashboard", (HttpContext context) =>
        {
            var tenant = context.Items["TenantId"]?.ToString();
            return $"Welcome to the dashboard for Organization: {tenant}. Your data is isolated.";
        });

        app.Run();
    }
}