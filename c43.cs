using System;

class NullableTypesDemo
{
    static void Main()
    {
        // Declaring nullable types
        int? nullableInt = null;
        double? nullableDouble = 5.5;
        bool? nullableBool = null;
        DateTime? nullableDate = DateTime.Now;

        // Checking if value is null
        Console.WriteLine("=== Nullable Types Demo ===\n");
        
        Console.WriteLine($"nullableInt is null: {!nullableInt.HasValue}");
        Console.WriteLine($"nullableDouble has value: {nullableDouble.HasValue}");
        Console.WriteLine($"nullableDouble value: {nullableDouble.Value}\n");

        // Using GetValueOrDefault()
        Console.WriteLine($"nullableInt (default): {nullableInt.GetValueOrDefault()}");
        Console.WriteLine($"nullableInt (custom default): {nullableInt.GetValueOrDefault(0)}\n");

        // Using null-coalescing operator
        int result = nullableInt ?? 10;
        Console.WriteLine($"nullableInt ?? 10 = {result}\n");

        // Assigning values
        nullableInt = 42;
        Console.WriteLine($"After assignment - nullableInt: {nullableInt.Value}");
        Console.WriteLine($"nullableInt.HasValue: {nullableInt.HasValue}\n");

        // Using in expressions
        if (nullableDouble.HasValue)
        {
            Console.WriteLine($"Double value doubled: {nullableDouble * 2}");
        }
    }
}