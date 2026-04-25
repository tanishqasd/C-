using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdvancedCSharp
{
    // 221. Expression Trees for Dynamic Queries
    // Instead of writing a dozen different if/else blocks to filter a database based on 
    // what the user clicked in the UI, Expression Trees allow you to build LINQ queries dynamically at runtime.

    public class Material
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Expression Trees (Dynamic LINQ) ---");

            var inventory = new List<Material>
            {
                new() { Name = "Cement", Stock = 50, Category = "Raw" },
                new() { Name = "Steel Beams", Stock = 10, Category = "Structural" },
                new() { Name = "Bricks", Stock = 5000, Category = "Raw" }
            }.AsQueryable();

            // Simulating UI filters: The user wants "Raw" materials with Stock > 100
            string filterCategory = "Raw";
            int minStock = 100;

            // Dynamically building the expression: m => m.Category == "Raw" && m.Stock > 100
            ParameterExpression param = Expression.Parameter(typeof(Material), "m");
            
            Expression categoryCheck = Expression.Equal(
                Expression.Property(param, "Category"), 
                Expression.Constant(filterCategory));
                
            Expression stockCheck = Expression.GreaterThan(
                Expression.Property(param, "Stock"), 
                Expression.Constant(minStock));

            Expression combined = Expression.AndAlso(categoryCheck, stockCheck);
            
            // Compile the expression tree into an executable LINQ query
            var queryFilter = Expression.Lambda<Func<Material, bool>>(combined, param);

            // Execute the dynamic query
            var results = inventory.Where(queryFilter).ToList();

            foreach (var item in results)
            {
                Console.WriteLine($"Found: {item.Name} (Stock: {item.Stock})");
            }
        }
    }
}