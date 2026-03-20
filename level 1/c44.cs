using System;

class Program
{
    static void Main()
    {
        // var - type is inferred at compile-time
        var name = "John";
        var age = 25;
        var salary = 50000.50;
        
        Console.WriteLine("--- Using var ---");
        Console.WriteLine($"Name: {name}, Type: {name.GetType()}");
        Console.WriteLine($"Age: {age}, Type: {age.GetType()}");
        Console.WriteLine($"Salary: {salary}, Type: {salary.GetType()}");
        
        // dynamic - type is resolved at runtime
        dynamic dynValue = "Hello";
        Console.WriteLine("\n--- Using dynamic ---");
        Console.WriteLine($"Value: {dynValue}, Type: {dynValue.GetType()}");
        
        dynValue = 100;
        Console.WriteLine($"Value: {dynValue}, Type: {dynValue.GetType()}");
        
        dynValue = 45.75;
        Console.WriteLine($"Value: {dynValue}, Type: {dynValue.GetType()}");
        
        // var is type-safe (compile-time)
        Console.WriteLine("\n--- Type Safety ---");
        var x = 10;
        // x = "string"; // Error: Cannot assign string to int
        
        // dynamic allows runtime type checking
        dynamic y = 20;
        y = "Now I'm a string"; // No compile-time error
        Console.WriteLine($"Dynamic value: {y}");
    }
}