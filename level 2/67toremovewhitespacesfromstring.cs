using System;

class RemoveWhitespaces
{
    static void Main()
    {
        string input = "Hello World C Sharp";
        string result = RemoveWhitespacesFromString(input);
        
        Console.WriteLine($"Original: {input}");
        Console.WriteLine($"Without spaces: {result}");
    }
    
    static string RemoveWhitespacesFromString(string str)
    {
        return str.Replace(" ", "");
    }
}