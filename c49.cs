using System;

class MathClassDemo
{
    static void Main()
    {
        Console.WriteLine("=== Math Class Demonstration ===\n");

        // Absolute Value
        Console.WriteLine($"Abs(-15): {Math.Abs(-15)}");

        // Square Root
        Console.WriteLine($"Sqrt(16): {Math.Sqrt(16)}");

        // Power
        Console.WriteLine($"Pow(2, 3): {Math.Pow(2, 3)}");

        // Rounding
        Console.WriteLine($"Round(3.7): {Math.Round(3.7)}");
        Console.WriteLine($"Floor(3.7): {Math.Floor(3.7)}");
        Console.WriteLine($"Ceiling(3.2): {Math.Ceiling(3.2)}");

        // Min and Max
        Console.WriteLine($"Min(5, 10): {Math.Min(5, 10)}");
        Console.WriteLine($"Max(5, 10): {Math.Max(5, 10)}");

        // Trigonometric Functions
        Console.WriteLine($"Sin(Math.PI/2): {Math.Sin(Math.PI / 2)}");
        Console.WriteLine($"Cos(0): {Math.Cos(0)}");

        // Logarithmic Functions
        Console.WriteLine($"Log(10): {Math.Log10(10)}");

        // Constants
        Console.WriteLine($"Math.PI: {Math.PI}");
        Console.WriteLine($"Math.E: {Math.E}");
    }
}