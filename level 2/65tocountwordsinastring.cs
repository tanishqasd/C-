using System;

class CountWordsInString
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        int wordCount = CountWords(input);
        Console.WriteLine($"Number of words: {wordCount}");
    }
    
    static int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;
        
        string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, 
                                    StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}