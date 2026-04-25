using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// A dummy dataset of 20 products
var productCatalog = Enumerable.Range(1, 20).Select(i => new 
{ 
    Id = i, 
    Name = $"Product {i}", 
    Category = i % 2 == 0 ? "Electronics" : "Furniture" 
}).ToList();

// Endpoint accepting Query Parameters for filtering and pagination
app.MapGet("/api/products", (string? category, int page = 1, int pageSize = 5) =>
{
    var query = productCatalog.AsQueryable();

    // 1. FILTERING
    // If a category was provided in the URL (e.g., ?category=Electronics), filter the list
    if (!string.IsNullOrEmpty(category))
    {
        query = query.Where(p => p.Category == category);
    }

    // 2. PAGINATION
    // Skip the records from previous pages, and Take only the amount for the current page
    var paginatedResult = query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return Results.Ok(new 
    {
        CurrentPage = page,
        PageSize = pageSize,
        TotalItemsMatchingFilter = query.Count(),
        Data = paginatedResult
    });
});

app.Run();