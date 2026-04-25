using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. Enforce HTTPS across the entire application
app.UseHttpsRedirection();

// 2. Add Security Headers middleware to prevent XSS and Clickjacking
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
    await next();
});

// 3. Input Validation using Data Annotations (Never trust user input!)
public class WorkerInput
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only letters are allowed.")]
    public string FullName { get; set; }
}

app.MapPost("/api/secure/workers", (WorkerInput input) =>
{
    // The framework automatically validates the input based on the attributes above.
    // 4. Output Encoding: If we ever return user data, encode it to prevent XSS attacks.
    string safeName = HtmlEncoder.Default.Encode(input.FullName);
    
    return Results.Ok(new { Message = $"Worker {safeName} securely added." });
});

app.Run();