using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        int iterations = 50000;
        Console.WriteLine("--- Performance Optimization Basics ---");
        Console.WriteLine($"Appending a character {iterations} times...\n");

        // ==========================================================
        // 1. THE INEFFICIENT WAY (Standard String Concatenation)
        // ==========================================================
        Stopwatch slowTimer = Stopwatch.StartNew();
        string slowString = "";
        
        for (int i = 0; i < iterations; i++)
        {
            // BAD: This creates a brand new string object in memory 50,000 times!
            slowString += "a"; 
        }
        
        slowTimer.Stop();
        Console.WriteLine($"Slow approach (String +=): {slowTimer.ElapsedMilliseconds} milliseconds");

        // ==========================================================
        // 2. THE OPTIMIZED WAY (StringBuilder)
        // ==========================================================
        Stopwatch fastTimer = Stopwatch.StartNew();
        
        // GOOD: StringBuilder allocates a memory buffer and modifies it directly.
        StringBuilder fastString = new StringBuilder();
        
        for (int i = 0; i < iterations; i++)
        {
            fastString.Append("a"); 
        }
        
        fastTimer.Stop();
        Console.WriteLine($"Optimized approach (StringBuilder): {fastTimer.ElapsedMilliseconds} milliseconds");

        Console.WriteLine("\n--- End of Demo ---");
    }
}