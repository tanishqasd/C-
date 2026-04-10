using System;

class Program
{
    static void Main()
    {
        // Calling method with all parameters
        DisplayInfo("Alice", 25, "Engineering");
        
        // Calling method with optional parameters omitted
        DisplayInfo("Bob", 30);
        DisplayInfo("Charlie");
    }
    
    static void DisplayInfo(string name, int age = 0, string department = "Not Specified")
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Department: {department}");
        Console.WriteLine();
    }
}