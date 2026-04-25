using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// 1. The Entity Model
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

// 2. The Database Context
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Using an In-Memory database for rapid demonstration
        optionsBuilder.UseInMemoryDatabase("TestDb");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Entity Framework Core CRUD ---");

        using (var context = new AppDbContext())
        {
            // CREATE
            context.Products.Add(new Product { Name = "Laptop", Price = 1200.00m });
            context.SaveChanges();
            Console.WriteLine("Product saved to database.");

            // READ
            var product = context.Products.FirstOrDefault(p => p.Name == "Laptop");
            Console.WriteLine($"Found Product: {product.Name} - ${product.Price}");

            // UPDATE
            product.Price = 1100.00m;
            context.SaveChanges();
            Console.WriteLine("Product price updated.");

            // DELETE
            context.Products.Remove(product);
            context.SaveChanges();
            Console.WriteLine("Product deleted.");
        }
    }
}