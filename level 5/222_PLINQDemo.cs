using System;
using System.Linq;
using System.Diagnostics;

namespace AdvancedCSharp
{
    // 222. PLINQ (Parallel LINQ)
    // PLINQ automatically splits a massive collection of data and processes the chunks 
    // simultaneously across all available CPU cores.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- PLINQ (Parallel LINQ) ---");

            // Generating 10 million simulated site telemetry records
            var telemetryData = Enumerable.Range(1, 10_000_000).ToArray();
            
            Stopwatch sw = Stopwatch.StartNew();

            // STANDARD LINQ (Single Core)
            var slowResults = telemetryData.Where(x => x % 2 == 0 && Math.Sqrt(x) > 1000).ToList();
            sw.Stop();
            Console.WriteLine($"Standard LINQ took: {sw.ElapsedMilliseconds} ms");

            sw.Restart();

            // PLINQ (Multi-Core CPU Utilization)
            // AsParallel() tells the framework to divide the work across the CPU threads
            var fastResults = telemetryData.AsParallel()
                                           .WithDegreeOfParallelism(Environment.ProcessorCount)
                                           .Where(x => x % 2 == 0 && Math.Sqrt(x) > 1000)
                                           .ToList();
            sw.Stop();
            Console.WriteLine($"PLINQ took: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"[Processed {fastResults.Count} complex records.]");
        }
    }
}