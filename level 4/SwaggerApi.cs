using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Generates the JSON blueprint of your API

var app = builder.Build();

// 2. Enable Swagger Middleware
// In a real app, you usually wrap this in 'if (app.Environment.IsDevelopment())'
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Cool API V1");
    c.RoutePrefix = string.Empty; // Serves the UI right at the root URL (localhost:port/)
});

// 3. Documented Endpoints
app.MapGet("/api/products", () => new[] { "Laptop", "Mouse", "Keyboard" })
   .WithTags("Inventory") // Groups this endpoint under 'Inventory' in the UI
   .WithSummary("Retrieves all active products.");

app.MapPost("/api/products", (string name) => $"Created product: {name}")
   .WithTags("Inventory")
   .WithSummary("Adds a new product to the catalog.");

app.Run();