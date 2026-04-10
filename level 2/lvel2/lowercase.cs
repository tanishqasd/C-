using System;

class StringCaseConversion
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        // Convert to uppercase
        string uppercase = input.ToUpper();
        Console.WriteLine($"Uppercase: {uppercase}");
        
        // Convert to lowercase
        string lowercase = input.ToLower();
        Console.WriteLine($"Lowercase: {lowercase}");
    }
}