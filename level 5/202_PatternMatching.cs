using System;

namespace AdvancedCSharp
{
    // 202. Advanced Pattern Matching replaces clunky if/else blocks with highly readable expressions.
    
    public record SiteWorker(string Name, string Role, int HoursLogged);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Advanced Pattern Matching ---");

            var worker = new SiteWorker("Alice", "Foreman", 45);

            // Using a switch expression with property patterns
            string payrollStatus = worker switch
            {
                { Role: "Foreman", HoursLogged: > 40 } => "Overtime Approved - Tier 1",
                { Role: "Laborer", HoursLogged: > 40 } => "Overtime Approved - Tier 2",
                { HoursLogged: < 20 } => "Part-Time Flagged",
                _ => "Standard Payroll Processing" // Default discard
            };

            Console.WriteLine($"Worker: {worker.Name} | Status: {payrollStatus}");
        }
    }
}