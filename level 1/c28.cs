using System;

class OperatorDemo
{
    static void Main()
    {
        // Arithmetic Operators
        int a = 10, b = 3;
        Console.WriteLine("=== Arithmetic Operators ===");
        Console.WriteLine($"a + b = {a + b}");
        Console.WriteLine($"a - b = {a - b}");
        Console.WriteLine($"a * b = {a * b}");
        Console.WriteLine($"a / b = {a / b}");
        Console.WriteLine($"a % b = {a % b}");

        // Comparison Operators
        Console.WriteLine("\n=== Comparison Operators ===");
        Console.WriteLine($"a == b: {a == b}");
        Console.WriteLine($"a != b: {a != b}");
        Console.WriteLine($"a > b: {a > b}");
        Console.WriteLine($"a < b: {a < b}");
        Console.WriteLine($"a >= b: {a >= b}");
        Console.WriteLine($"a <= b: {a <= b}");

        // Logical Operators
        bool x = true, y = false;
        Console.WriteLine("\n=== Logical Operators ===");
        Console.WriteLine($"x && y: {x && y}");
        Console.WriteLine($"x || y: {x || y}");
        Console.WriteLine($"!x: {!x}");

        // Assignment Operators
        Console.WriteLine("\n=== Assignment Operators ===");
        int c = 5;
        c += 3;
        Console.WriteLine($"After c += 3: {c}");
        c -= 2;
        Console.WriteLine($"After c -= 2: {c}");
        c *= 2;
        Console.WriteLine($"After c *= 2: {c}");

        // Bitwise Operators
        Console.WriteLine("\n=== Bitwise Operators ===");
        Console.WriteLine($"a & b: {a & b}");
        Console.WriteLine($"a | b: {a | b}");
        Console.WriteLine($"a ^ b: {a ^ b}");
        Console.WriteLine($"~a: {~a}");
    }
}