using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

// 1. The Entity Model
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
}

// 2. The Database Context
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Customer> Customers { get; set; }
}

var builder = WebApplication.CreateBuilder(args);

// 3. Register Entity Framework with an In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CustomerDb"));

var app = builder.Build();

// 4. Endpoints interacting directly with the Database
app.MapGet("/api/customers", async (AppDbContext db) =>
    await db.Customers.ToListAsync());

app.MapPost("/api/customers", async (Customer customer, AppDbContext db) =>
{
    db.Customers.Add(customer);
    await db.SaveChangesAsync();
    return Results.Created($"/api/customers/{customer.Id}", customer);
});

app.MapDelete("/api/customers/{id}", async (int id, AppDbContext db) =>
{
    var customer = await db.Customers.FindAsync(id);
    if (customer is null) return Results.NotFound();

    db.Customers.Remove(customer);
    await db.SaveChangesAsync();
    return Results.Ok("Customer deleted.");
});

app.Run();