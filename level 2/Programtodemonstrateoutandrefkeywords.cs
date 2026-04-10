using System;

class Program
{
    // Method with 'ref' keyword - parameter must be initialized before calling
    static void ModifyWithRef(ref int number)
    {
        number = number * 2;
    }

    // Method with 'out' keyword - parameter must be assigned before returning
    static void GetValuesWithOut(out int sum, out int product)
    {
        sum = 10 + 20;
        product = 10 * 20;
    }

    // Method demonstrating both ref and out
    static void ProcessNumbers(ref int x, out int result)
    {
        x = x + 5;
        result = x * 2;
    }

    static void Main()
    {
        Console.WriteLine("=== Demonstrating 'ref' keyword ===");
        int num = 10;
        Console.WriteLine($"Before ref method: {num}");
        ModifyWithRef(ref num);
        Console.WriteLine($"After ref method: {num}");

        Console.WriteLine("\n=== Demonstrating 'out' keyword ===");
        GetValuesWithOut(out int sum, out int product);
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Product: {product}");

        Console.WriteLine("\n=== Demonstrating both 'ref' and 'out' ===");
        int value = 15;
        Console.WriteLine($"Initial value: {value}");
        ProcessNumbers(ref value, out int finalResult);
        Console.WriteLine($"Modified value: {value}");
        Console.WriteLine($"Final result: {finalResult}");
    }
}