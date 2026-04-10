using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the original string: ");
        string originalString = Console.ReadLine();
        
        Console.Write("Enter the substring to find: ");
        string findSubstring = Console.ReadLine();
        
        Console.Write("Enter the replacement substring: ");
        string replaceSubstring = Console.ReadLine();
        
        // Replace substring
        string newString = originalString.Replace(findSubstring, replaceSubstring);
        
        Console.WriteLine($"\nOriginal String: {originalString}");
        Console.WriteLine($"Find: {findSubstring}");
        Console.WriteLine($"Replace with: {replaceSubstring}");
        Console.WriteLine($"Result: {newString}");
    }
}