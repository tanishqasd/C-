using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdvancedCSharp
{
    // 225. Entity Framework Interceptors
    // Interceptors allow you to automatically inject logic every time the database is queried or updated.
    // This is the enterprise standard for "Audit Logging" (tracking who changed what data and when).

    // The Custom Interceptor
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context;
            if (context == null) return result;

            // Find all entities being added or modified
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    Console.WriteLine($"[AUDIT LOG] Detected a {entry.State} operation on entity type: {entry.Entity.GetType().Name}");
                    // In a real app, you would save this exact timestamp and user ID to an Audit table here.
                }
            }

            return base.SavingChanges(eventData, result);
        }
    }

    // The Database Context
    public class ConstructionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Registering the interceptor to watch all database traffic
            optionsBuilder
                .UseInMemoryDatabase("AuditDemoDb")
                .AddInterceptors(new AuditInterceptor());
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- EF Core Interceptors ---");

            using (var db = new ConstructionDbContext())
            {
                Console.WriteLine("Attempting to save a new record...");
                
                // The interceptor will catch this automatically when SaveChanges is called!
                db.Add(new { Id = 1, Name = "Bulldozer" }); 
                db.SaveChanges();
            }
        }
    }
}