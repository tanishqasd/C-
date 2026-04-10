using System;

class MethodOverloadingDemo
{
    static void Main()
    {
        Console.WriteLine("=== Method Overloading Demonstration ===\n");

        // Calling Add with two integers
        Console.WriteLine($"Add(5, 10) = {Add(5, 10)}");

        // Calling Add with two doubles
        Console.WriteLine($"Add(5.5, 10.5) = {Add(5.5, 10.5)}");

        // Calling Add with three integers
        Console.WriteLine($"Add(5, 10, 15) = {Add(5, 10, 15)}");

        // Calling Add with two integers and one double
        Console.WriteLine($"Add(5, 10, 3.5) = {Add(5, 10, 3.5)}");

        // Calling Display with int
        Console.WriteLine("\nCalling Display with int:");
        Display(100);

        // Calling Display with string
        Console.WriteLine("Calling Display with string:");
        Display("Hello");

        // Calling Display with double
        Console.WriteLine("Calling Display with double:");
        Display(45.75);

        // Calling Display with int and string
        Console.WriteLine("Calling Display with int and string:");
        Display(1, "Item");
    }

    // Overloaded Add methods
    static int Add(int a, int b)
    {
        return a + b;
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    static double Add(int a, int b, double c)
    {
        return a + b + c;
    }

    // Overloaded Display methods
    static void Display(int num)
    {
        Console.WriteLine($"Integer: {num}");
    }

    static void Display(string text)
    {
        Console.WriteLine($"String: {text}");
    }

    static void Display(double num)
    {
        Console.WriteLine($"Double: {num}");
    }

    static void Display(int id, string name)
    {
        Console.WriteLine($"ID: {id}, Name: {name}");
    }
}