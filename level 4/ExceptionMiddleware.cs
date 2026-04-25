using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

// 1. Define the Custom Middleware Class
public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Try to proceed to the next step in the pipeline (e.g., the API endpoint)
            await _next(context);
        }
        catch (Exception ex)
        {
            // If the endpoint crashes, catch the error here globally!
            Console.WriteLine($"[CRITICAL LOG] An error occurred: {ex.Message}");
            
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("{\"error\": \"An unexpected server error occurred. Please try again later.\"}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // 2. Register the Custom Middleware early in the pipeline
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

        // 3. A risky endpoint that will crash
        app.MapGet("/api/risky", () => 
        {
            throw new InvalidOperationException("The database connection failed!");
        });

        app.Run();
    }
}