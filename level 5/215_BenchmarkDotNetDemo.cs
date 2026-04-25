using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AdvancedCSharp
{
    // 215. BenchmarkDotNet Performance Testing
    // This is the industry-standard tool for mathematically proving which piece of code 
    // is faster. It automatically runs warmups, prevents compiler tricks, and tracks memory.

    [MemoryDiagnoser] // Tells the tool to track memory allocations
    public class ReportGeneratorBenchmark
    {
        int _iterations = 1000;

        [Benchmark(Baseline = true)]
        public string InefficientStringConcat()
        {
            string report = "";
            for (int i = 0; i < _iterations; i++)
            {
                report += "Data;";
            }
            return report;
        }

        [Benchmark]
        public string OptimizedStringBuilder()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _iterations; i++)
            {
                sb.Append("Data;");
            }
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- BenchmarkDotNet Setup ---");
            Console.WriteLine("To run this correctly, compile in RELEASE mode and execute:");
            Console.WriteLine("BenchmarkRunner.Run<ReportGeneratorBenchmark>();\n");
            
            // Uncomment the line below in a real project to run the extensive benchmark suite
            // var summary = BenchmarkRunner.Run<ReportGeneratorBenchmark>();
        }
    }
}