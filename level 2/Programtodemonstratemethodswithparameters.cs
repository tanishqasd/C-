using System;

class MethodsWithParameters
{
    // Method with single parameter
    static void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }

    // Method with multiple parameters
    static void Add(int a, int b)
    {
        int sum = a + b;
        Console.WriteLine($"{a} + {b} = {sum}");
    }

    // Method with parameters and return type
    static int Multiply(int x, int y)
    {
        return x * y;
    }

    // Method with default parameters
    static void DisplayInfo(string name, string city = "Unknown")
    {
        Console.WriteLine($"Name: {name}, City: {city}");
    }

    // Method with out parameter
    static void Divide(int dividend, int divisor, out int quotient, out int remainder)
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    static void Main()
    {
        // Call methods with different parameters
        Greet("Tanishqa");
        
        Add(10, 20);
        
        int result = Multiply(5, 6);
        Console.WriteLine($"5 * 6 = {result}");
        
        DisplayInfo("John");
        DisplayInfo("Jane", "New York");
        
        Divide(17, 5, out int q, out int r);
        Console.WriteLine($"17 / 5 = {q} with remainder {r}");
    }
}