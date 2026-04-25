using System;

class Program
{
    // Delegate definition
    delegate int MathOperation(int x, int y);

    static void Main()
    {
        // Using a lambda expression (=>) to define the method inline
        MathOperation add = (a, b) => a + b;
        MathOperation multiply = (a, b) => a * b;

        Console.WriteLine($"Addition: {add(5, 3)}");
        Console.WriteLine($"Multiplication: {multiply(5, 3)}");
    }
}