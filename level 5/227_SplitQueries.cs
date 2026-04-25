using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AdvancedCSharp
{
    // 227. EF Core Split Queries
    // When you "Include" multiple child tables (e.g., A Site has many Workers AND many Materials),
    // standard EF Core creates a massive, bloated SQL JOIN (Cartesian Explosion).
    // .AsSplitQuery() forces EF Core to run separate, clean queries and stitch them together in RAM.

    public class Site 
    { 
        public int Id { get; set; } 
        public List<Worker> Workers { get; set; } 
        public List<Material> Materials { get; set; } 
    }
    public class Material { public int Id { get; set; } }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- EF Core Split Queries ---");

            // using var db = new AppDbContext();

            Console.WriteLine("Fetching complex site data...");

            // THE EFFICIENT WAY for multi-collection includes
            // var siteData = db.Sites
            //     .Include(s => s.Workers)
            //     .Include(s => s.Materials)
            //     .AsSplitQuery() // <-- The magic method
            //     .FirstOrDefault(s => s.Id == 1);

            Console.WriteLine("[Simulated] EF Core executed 3 fast, independent SELECT statements instead of 1 massive JOIN.");
        }
    }
}