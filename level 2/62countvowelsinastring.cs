using System;

class CountVowels
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        int vowelCount = 0;
        string vowels = "aeiouAEIOU";
        
        foreach (char c in input)
        {
            if (vowels.Contains(c))
            {
                vowelCount++;
            }
        }
        
        Console.WriteLine($"Number of vowels: {vowelCount}");
    }
}