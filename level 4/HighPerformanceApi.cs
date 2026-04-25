using System;

// When building high-performance APIs (handling thousands of requests per second),
// you must minimize memory allocations. Every time you create a new string, the 
// Garbage Collector has to clean it up later, which slows down the server.

class Program
{
    static void Main()
    {
        Console.WriteLine("--- High Performance C# (Span<T>) ---\n");
        
        // Scenario: We receive a raw text string from a sensor and need to extract the ID.
        string rawData = "OrderId:998877,Status:Active";
        
        // ==========================================================
        // 1. THE SLOW WAY (Standard Strings)
        // ==========================================================
        // Split() creates an array, and Substring() creates a brand new string in memory.
        string[] parts = rawData.Split(',');
        string orderPart = parts[0].Substring(8); 
        
        Console.WriteLine($"[Inefficient] Extracted ID: {orderPart}");

        // ==========================================================
        // 2. THE HIGH-PERFORMANCE WAY (ReadOnlySpan<T>)
        // ==========================================================
        // Span<T> acts as a "window" over existing memory. 
        // It slices the data WITHOUT allocating any new memory whatsoever!
        
        ReadOnlySpan<char> rawDataSpan = rawData.AsSpan();
        int commaIndex = rawDataSpan.IndexOf(',');
        
        ReadOnlySpan<char> orderSpan = rawDataSpan.Slice(8, commaIndex - 8);
        
        Console.WriteLine($"[High-Perf] Extracted ID: {orderSpan.ToString()}");
        
        Console.WriteLine("\n[Note: In a massive loop, Span<T> is exponentially faster.]");
    }
}