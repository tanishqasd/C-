using System;

class Calculator
{
    // Static method
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // Static method
    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    // Static method
    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    // Static method
    public static double Divide(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Division by zero!");
            return 0;
        }
        return (double)a / b;
    }
}

class Program
{
    static void Main()
    {
        // Calling static methods without creating an instance
        Console.WriteLine("Addition: " + Calculator.Add(10, 5));
        Console.WriteLine("Subtraction: " + Calculator.Subtract(10, 5));
        Console.WriteLine("Multiplication: " + Calculator.Multiply(10, 5));
        Console.WriteLine("Division: " + Calculator.Divide(10, 5));
    }
}