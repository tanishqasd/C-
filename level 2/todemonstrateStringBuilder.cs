using System;
using System.Text;
using System.Diagnostics;

class StringBuilderDemo
{
    static void Main()
    {
        Console.WriteLine("=== StringBuilder Demonstration ===\n");

        // 1. Basic StringBuilder operations
        Console.WriteLine("1. Basic Operations:");
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(" ");
        sb.Append("World");
        Console.WriteLine($"Result: {sb}");

        // 2. AppendLine
        Console.WriteLine("\n2. AppendLine:");
        sb.Clear();
        sb.AppendLine("Line 1");
        sb.AppendLine("Line 2");
        sb.AppendLine("Line 3");
        Console.WriteLine(sb);

        // 3. Insert
        Console.WriteLine("3. Insert:");
        sb.Clear();
        sb.Append("Hello World");
        sb.Insert(6, "Beautiful ");
        Console.WriteLine($"Result: {sb}");

        // 4. Remove
        Console.WriteLine("4. Remove:");
        sb.Remove(6, 10);
        Console.WriteLine($"Result: {sb}");

        // 5. Replace
        Console.WriteLine("\n5. Replace:");
        sb.Clear();
        sb.Append("The quick brown fox");
        sb.Replace("quick", "slow");
        Console.WriteLine($"Result: {sb}");

        // 6. Performance comparison
        Console.WriteLine("\n6. Performance Comparison:");
        PerformanceComparison();
    }

    static void PerformanceComparison()
    {
        int iterations = 10000;
        Stopwatch sw = new Stopwatch();

        // String concatenation
        sw.Start();
        string result = "";
        for (int i = 0; i < iterations; i++)
        {
            result += i;
        }
        sw.Stop();
        Console.WriteLine($"String concatenation: {sw.ElapsedMilliseconds} ms");

        // StringBuilder
        sw.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append(i);
        }
        sw.Stop();
        Console.WriteLine($"StringBuilder: {sw.ElapsedMilliseconds} ms");
    }
}