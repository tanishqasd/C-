using System;

class StringInterpolationDemo
{
    static void Main()
    {
        string name = "Alice";
        int age = 25;
        double salary = 75000.50;
        DateTime today = DateTime.Now;

        // Basic string interpolation
        Console.WriteLine($"Name: {name}");
        
        // Multiple variables
        Console.WriteLine($"{name} is {age} years old.");
        
        // With formatting
        Console.WriteLine($"Salary: ${salary:F2}");
        
        // With expressions
        Console.WriteLine($"Next year {name} will be {age + 1} years old.");
        
        // Date formatting
        Console.WriteLine($"Today's date: {today:dd/MM/yyyy}");
        
        // Arithmetic operations
        int x = 10, y = 20;
        Console.WriteLine($"Sum of {x} and {y} is {x + y}");
    }
}