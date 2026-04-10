using System;

class Program
{
    static void Main()
    {
        // Named arguments allow you to specify arguments by name
        // This makes code more readable and flexible
        
        // Example 1: Basic named arguments
        PrintPersonInfo(name: "John", age: 30, city: "New York");
        
        // Example 2: Different order with named arguments
        PrintPersonInfo(city: "London", name: "Jane", age: 25);
        
        // Example 3: Mix of positional and named arguments
        CalculateTotal(100, discount: 10, taxRate: 0.05);
    }
    
    static void PrintPersonInfo(string name, int age, string city)
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"City: {city}");
        Console.WriteLine();
    }
    
    static void CalculateTotal(decimal amount, decimal discount, decimal taxRate)
    {
        decimal afterDiscount = amount - discount;
        decimal total = afterDiscount + (afterDiscount * taxRate);
        Console.WriteLine($"Amount: {amount}");
        Console.WriteLine($"Discount: {discount}");
        Console.WriteLine($"Tax Rate: {taxRate}");
        Console.WriteLine($"Total: {total}");
    }
}