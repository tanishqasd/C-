using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharp
{
    // 223. IQueryable vs IEnumerable (Enterprise Data fetching)
    // Understanding this difference prevents you from accidentally crashing your database.
    // IEnumerable executes filters in RAM (Client-side).
    // IQueryable translates filters to SQL and executes them inside the Database (Server-side).

    public class Worker { public int Id { get; set; } public string Role { get; set; } }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- IQueryable vs IEnumerable ---");

            // Simulating an Entity Framework Database Table containing 100,000 workers
            IQueryable<Worker> databaseTable = GenerateMockDatabase();

            // 1. THE DANGEROUS WAY (IEnumerable)
            // Calling .ToList() downloads ALL 100,000 records into RAM, THEN filters them.
            IEnumerable<Worker> inMemoryList = databaseTable.ToList(); 
            var foremanListBad = inMemoryList.Where(w => w.Role == "Foreman").Take(5).ToList();

            // 2. THE ENTERPRISE WAY (IQueryable)
            // The query remains an IQueryable until .ToList() is called at the very end.
            // This translates directly to: SELECT TOP 5 * FROM Workers WHERE Role = 'Foreman'
            var foremanListGood = databaseTable.Where(w => w.Role == "Foreman").Take(5).ToList();

            Console.WriteLine("Always apply filters to IQueryable BEFORE calling .ToList() or .ToArray().");
        }

        static IQueryable<Worker> GenerateMockDatabase()
        {
            return new List<Worker> { new() { Id = 1, Role = "Foreman" } }.AsQueryable();
        }
    }
}