using System;

// Extension methods must be inside a static, non-generic class
public static class StringExtensions
{
    // The 'this' keyword tells the compiler it extends the string class
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

class Program
{
    static void Main()
    {
        string text = "Learning C# is fun.";
        Console.WriteLine($"Word count: {text.WordCount()}"); // Called exactly like an instance method!
    }
}