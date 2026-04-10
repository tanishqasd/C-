using System;

class StringFormattingDemo
{
    static void Main()
    {
        Console.WriteLine("=== String Formatting Demonstration ===\n");

        // 1. String Interpolation
        Console.WriteLine("1. String Interpolation:");
        string name = "Alice";
        int age = 28;
        Console.WriteLine($"Name: {name}, Age: {age}");
        Console.WriteLine();

        // 2. Composite Formatting
        Console.WriteLine("2. Composite Formatting:");
        Console.WriteLine("Name: {0}, Age: {1}", name, age);
        Console.WriteLine();

        // 3. Number Formatting
        Console.WriteLine("3. Number Formatting:");
        double salary = 75000.50;
        Console.WriteLine($"Currency: {salary:C}");
        Console.WriteLine($"Fixed 2 decimals: {salary:F2}");
        Console.WriteLine($"Percentage: {0.85:P}");
        Console.WriteLine();

        // 4. Date Formatting
        Console.WriteLine("4. Date Formatting:");
        DateTime today = DateTime.Now;
        Console.WriteLine($"Short date: {today:d}");
        Console.WriteLine($"Long date: {today:D}");
        Console.WriteLine($"Custom date: {today:dd/MM/yyyy}");
        Console.WriteLine($"Time: {today:HH:mm:ss}");
        Console.WriteLine();

        // 5. Alignment and Padding
        Console.WriteLine("5. Alignment and Padding:");
        Console.WriteLine($"Left aligned: |{name,-15}|");
        Console.WriteLine($"Right aligned: |{name,15}|");
        Console.WriteLine();

        // 6. Expressions in Interpolation
        Console.WriteLine("6. Expressions in Interpolation:");
        int x = 10, y = 20;
        Console.WriteLine($"Sum: {x + y}");
        Console.WriteLine($"Product: {x * y}");
        Console.WriteLine();

        // 7. Escape Characters
        Console.WriteLine("7. Escape Characters:");
        Console.WriteLine("Quote: \"Hello\"");
        Console.WriteLine("Backslash: \\");
        Console.WriteLine("Tab:\tSeparated");
        Console.WriteLine("Newline:\nNew line");
    }
}