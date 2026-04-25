using System;
using System.Collections.Generic;

namespace AdvancedTesting
{
    // 289. Memory Leak Detection (Diagnostic Basics).
    // Explains how to use 'dotnet-dump' to find why your C# app is using 4GB of RAM.
    
    class Program
    {
        // Common culprit: Static lists that never get cleared
        private static readonly List<byte[]> _leakSource = new();

        static void Main()
        {
            Console.WriteLine("--- Memory Diagnostic Strategy ---");
            Console.WriteLine("1. Run 'dotnet-counters monitor -p [PID]' to watch RAM.");
            Console.WriteLine("2. If RAM grows indefinitely, run 'dotnet-dump collect'.");
            Console.WriteLine("3. Analyze the dump with 'dotnet-dump analyze' using 'dumpheap -stat'.");
        }
    }
}