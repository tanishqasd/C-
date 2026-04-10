using System;

class SpanAndReadOnlySpanDemo
{
    static void Main()
    {
        Console.WriteLine("=== Span and ReadOnlySpan Demonstration ===\n");

        // Example 1: Span with array
        Console.WriteLine("Example 1: Span with Array");
        int[] numbers = { 10, 20, 30, 40, 50 };
        Span<int> span = new Span<int>(numbers);
        Console.WriteLine($"Original array: {string.Join(", ", numbers)}");
        span[2] = 35; // Modify through span
        Console.WriteLine($"After modification: {string.Join(", ", numbers)}\n");

        // Example 2: Span slicing
        Console.WriteLine("Example 2: Span Slicing");
        Span<int> slicedSpan = span.Slice(1, 3); // Start at index 1, take 3 elements
        Console.WriteLine($"Sliced span: {string.Join(", ", slicedSpan.ToArray())}\n");

        // Example 3: ReadOnlySpan with array
        Console.WriteLine("Example 3: ReadOnlySpan with Array");
        ReadOnlySpan<int> readOnlySpan = new ReadOnlySpan<int>(numbers);
        Console.WriteLine($"ReadOnlySpan content: {string.Join(", ", readOnlySpan.ToArray())}");
        // readOnlySpan[0] = 100; // Error: Cannot modify ReadOnlySpan
        Console.WriteLine();

        // Example 4: ReadOnlySpan slicing
        Console.WriteLine("Example 4: ReadOnlySpan Slicing");
        ReadOnlySpan<int> readOnlySlice = readOnlySpan.Slice(2, 2);
        Console.WriteLine($"ReadOnlySpan sliced: {string.Join(", ", readOnlySlice.ToArray())}\n");

        // Example 5: Span with string
        Console.WriteLine("Example 5: Span with String");
        string text = "Hello";
        Span<char> charSpan = text.ToCharArray().AsSpan();
        charSpan[0] = 'J';
        Console.WriteLine($"Modified char span: {new string(charSpan)}\n");

        // Example 6: Method using Span
        Console.WriteLine("Example 6: Method Using Span");
        int[] data = { 5, 15, 25, 35, 45 };
        Console.WriteLine($"Average: {CalculateAverage(data.AsSpan())}");
    }

    // Method that accepts ReadOnlySpan for better performance
    static double CalculateAverage(ReadOnlySpan<int> values)
    {
        if (values.Length == 0) return 0;
        int sum = 0;
        foreach (int value in values)
        {
            sum += value;
        }
        return (double)sum / values.Length;
    }
}