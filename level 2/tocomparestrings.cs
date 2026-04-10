using System;

class StringComparison
{
    static void Main()
    {
        string str1 = "Hello";
        string str2 = "Hello";
        string str3 = "World";

        // Compare using == operator
        Console.WriteLine($"str1 == str2: {str1 == str2}");
        Console.WriteLine($"str1 == str3: {str1 == str3}");

        // Compare using string.Compare()
        Console.WriteLine($"string.Compare(str1, str2): {string.Compare(str1, str2)}");
        Console.WriteLine($"string.Compare(str1, str3): {string.Compare(str1, str3)}");

        // Compare using string.Equals()
        Console.WriteLine($"str1.Equals(str2): {str1.Equals(str2)}");
        Console.WriteLine($"str1.Equals(str3): {str1.Equals(str3)}");

        // Case-insensitive comparison
        string str4 = "HELLO";
        Console.WriteLine($"str1.Equals(str4, StringComparison.OrdinalIgnoreCase): {str1.Equals(str4, StringComparison.OrdinalIgnoreCase)}");
    }
}