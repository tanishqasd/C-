using System;

namespace AdvancedCSharp
{
    // 212. Memory<T> and Span<T> Advanced Usage
    // Span<T> is for synchronous operations, while Memory<T> can be used asynchronously.
    // Both allow you to slice strings and arrays without allocating new memory.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Memory<T> and Span<T> ---");

            // A raw check-in log: "SiteCode-WorkerID-Timestamp"
            string rawLog = "BLD001-WKR8492-1684920000";
            
            // Convert to a memory span for zero-allocation parsing
            ReadOnlySpan<char> logSpan = rawLog.AsSpan();

            // Slicing out the Site Code (First 6 characters)
            ReadOnlySpan<char> siteCode = logSpan.Slice(0, 6);
            
            // Finding the Worker ID dynamically
            int firstDash = logSpan.IndexOf('-');
            int secondDash = logSpan.LastIndexOf('-');
            
            ReadOnlySpan<char> workerId = logSpan.Slice(firstDash + 1, secondDash - firstDash - 1);

            Console.WriteLine($"Raw Log: {rawLog}");
            Console.WriteLine($"Extracted Site: {siteCode.ToString()}");
            Console.WriteLine($"Extracted Worker: {workerId.ToString()}");
            Console.WriteLine("[Parsed zero new strings in memory!]");
        }
    }
}