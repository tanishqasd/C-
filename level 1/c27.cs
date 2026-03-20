using System;

class Program
{
    // Constants - compile-time, cannot be changed
    private const double PI = 3.14159;
    private const int MAX_USERS = 100;
    
    // Readonly - runtime, cannot be changed after initialization
    private readonly string CompanyName;
    private readonly DateTime CreatedDate;
    
    public Program(string companyName)
    {
        CompanyName = companyName;
        CreatedDate = DateTime.Now;
    }
    
    static void Main()
    {
        Console.WriteLine("=== Constants and Readonly Demo ===\n");
        
        // Constants
        Console.WriteLine("Constants (Compile-time):");
        Console.WriteLine($"PI = {PI}");
        Console.WriteLine($"MAX_USERS = {MAX_USERS}");
        
        // Attempting to change constant will cause compile error
        // PI = 3.14; // Error: Cannot assign to readonly variable
        
        Console.WriteLine("\nReadonly (Runtime):");
        Program program = new Program("TechCorp");
        Console.WriteLine($"CompanyName = {program.CompanyName}");
        Console.WriteLine($"CreatedDate = {program.CreatedDate}");
        
        // Attempting to change readonly will cause error
        // program.CompanyName = "NewCorp"; // Error: Cannot assign to readonly property
        
        Console.WriteLine("\nKey Differences:");
        Console.WriteLine("- Constants: Fixed at compile-time, must be initialized");
        Console.WriteLine("- Readonly: Can be initialized at runtime, in constructor or declaration");
    }
}