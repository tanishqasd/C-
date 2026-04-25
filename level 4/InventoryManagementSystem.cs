using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string SKU { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
}

class Program
{
    static List<Product> inventory = new List<Product>
    {
        new Product { SKU = "A1", Name = "Laptop", Stock = 50 }
    };

    static void Main()
    {
        Console.WriteLine("--- Inventory Management ---");
        UpdateStock("A1", -5); // Sold 5 laptops
        UpdateStock("A1", 20); // Received shipment of 20 laptops
        UpdateStock("B2", 10); // Attempt to update non-existent item
    }

    static void UpdateStock(string sku, int quantityChange)
    {
        var product = inventory.FirstOrDefault(p => p.SKU == sku);
        if (product != null)
        {
            product.Stock += quantityChange;
            Console.WriteLine($"[Updated] {product.Name} stock is now {product.Stock}");
        }
        else
        {
            Console.WriteLine($"[Error] Product with SKU {sku} not found.");
        }
    }
}