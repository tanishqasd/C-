using System;
using System.Text.RegularExpressions;

class RemoveSpecialCharacters
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        string result = RemoveSpecialChars(input);
        
        Console.WriteLine($"Original: {input}");
        Console.WriteLine($"Without special characters: {result}");
    }
    
    static string RemoveSpecialChars(string str)
    {
        // Keep only alphanumeric characters and spaces
        return Regex.Replace(str, "[^a-zA-Z0-9 ]", "");
    }
}