using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// 1. Register the modern .NET 8 IExceptionHandler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails(); // Follows RFC 7807 standard for REST API errors

var app = builder.Build();

// 2. Add the exception handler middleware to the pipeline
app.UseExceptionHandler();

app.MapGet("/api/fail", () => 
{
    throw new InvalidOperationException("Database connection timeout.");
});

app.Run();

// 3. The Handler Implementation
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) => _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // Log the actual secure error internally
        _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

        // Return a sanitized, standardized 'ProblemDetails' response to the client
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server Error",
            Detail = "An unexpected error occurred. Our engineers have been notified.",
            Instance = httpContext.Request.Path
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true; // Tells the pipeline the exception was successfully handled
    }
}