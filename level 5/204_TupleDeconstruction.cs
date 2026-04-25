using System;

namespace AdvancedCSharp
{
    // 204. Tuple Deconstruction allows methods to return multiple values elegantly,
    // avoiding the need to create clunky "Out" parameters or temporary classes.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Tuple Deconstruction ---");

            // Deconstructing the returned tuple directly into three distinct variables
            var (siteId, isOperational, activeWorkers) = GetSiteStatus("BLD-001");

            Console.WriteLine($"Site ID: {siteId}");
            Console.WriteLine($"Operational: {isOperational}");
            Console.WriteLine($"Active Workers: {activeWorkers}");
        }

        // Method returning a named tuple
        static (string SiteId, bool IsOperational, int ActiveWorkers) GetSiteStatus(string siteCode)
        {
            // Simulate database lookup
            return (siteCode, true, 142);
        }
    }
}