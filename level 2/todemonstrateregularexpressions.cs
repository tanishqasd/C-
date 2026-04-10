using System;
using System.Text.RegularExpressions;

class RegularExpressionsDemo
{
    static void Main()
    {
        Console.WriteLine("=== Regular Expressions Demonstration ===\n");

        // Example 1: Validate email
        Console.WriteLine("Example 1: Email Validation");
        ValidateEmail("user@example.com");
        ValidateEmail("invalid.email@");
        Console.WriteLine();

        // Example 2: Validate phone number
        Console.WriteLine("Example 2: Phone Number Validation");
        ValidatePhoneNumber("123-456-7890");
        ValidatePhoneNumber("12345");
        Console.WriteLine();

        // Example 3: Pattern matching
        Console.WriteLine("Example 3: Pattern Matching");
        string text = "The numbers are 123, 456, and 789";
        MatchPattern(text, @"\d+");
        Console.WriteLine();

        // Example 4: Replace text
        Console.WriteLine("Example 4: Replace Text");
        string sentence = "Hello World, Welcome to .NET";
        string replaced = Regex.Replace(sentence, @"\b\w", m => m.Value.ToUpper());
        Console.WriteLine($"Original: {sentence}");
        Console.WriteLine($"Replaced: {replaced}\n");

        // Example 5: Split text
        Console.WriteLine("Example 5: Split Text");
        string csvData = "apple,banana,orange,grape";
        string[] fruits = Regex.Split(csvData, ",");
        Console.WriteLine("Fruits:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine($"  - {fruit}");
        }
        Console.WriteLine();

        // Example 6: Extract words
        Console.WriteLine("Example 6: Extract Words");
        string paragraph = "C# is great for development. Learn C# today!";
        ExtractWords(paragraph);
    }

    static void ValidateEmail(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        bool isValid = Regex.IsMatch(email, pattern);
        Console.WriteLine($"Email: {email} - Valid: {isValid}");
    }

    static void ValidatePhoneNumber(string phone)
    {
        string pattern = @"^\d{3}-\d{3}-\d{4}$";
        bool isValid = Regex.IsMatch(phone, pattern);
        Console.WriteLine($"Phone: {phone} - Valid: {isValid}");
    }

    static void MatchPattern(string text, string pattern)
    {
        MatchCollection matches = Regex.Matches(text, pattern);
        Console.WriteLine($"Text: {text}");
        Console.WriteLine($"Matches found: {matches.Count}");
        foreach (Match match in matches)
        {
            Console.WriteLine($"  - {match.Value}");
        }
    }

    static void ExtractWords(string text)
    {
        MatchCollection words = Regex.Matches(text, @"\b\w+\b");
        Console.WriteLine($"Text: {text}");
        Console.WriteLine("Words extracted:");
        foreach (Match word in words)
        {
            Console.WriteLine($"  - {word.Value}");
        }
    }
}