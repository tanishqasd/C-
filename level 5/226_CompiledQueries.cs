using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdvancedCSharp
{
    // 226. EF Core Compiled Queries
    // Normally, Entity Framework translates your LINQ query into SQL every single time it runs.
    // "Compiled Queries" translate the query ONCE, cache the SQL, and reuse it, 
    // making high-frequency lookups significantly faster.

    public class Worker { public int Id { get; set; } public string SiteCode { get; set; } }
    public class AppDbContext : DbContext { public DbSet<Worker> Workers { get; set; } }

    class Program
    {
        // 1. Define the compiled query as a static delegate
        private static readonly Func<AppDbContext, string, IAsyncEnumerable<Worker>> GetWorkersBySite =
            EF.CompileAsyncQuery((AppDbContext db, string siteCode) =>
                db.Workers.Where(w => w.SiteCode == siteCode));

        static async Task Main()
        {
            Console.WriteLine("--- EF Core Compiled Queries ---");

            // Assuming 'db' is injected in a real application
            // using var db = new AppDbContext(); 
            
            Console.WriteLine("Querying Site A workers using pre-compiled SQL...");
            
            // 2. Execute the pre-compiled query lightning fast
            // await foreach (var worker in GetWorkersBySite(db, "BLD-001"))
            // {
            //     Console.WriteLine($"Found Worker ID: {worker.Id}");
            // }
            
            Console.WriteLine("[Execution simulated. The SQL translation phase was skipped!]");
        }
    }
}