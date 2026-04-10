using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        // Convert to lowercase for case-insensitive counting
        input = input.ToLower();
        
        // Count frequency of each character
        Dictionary<char, int> frequency = new Dictionary<char, int>();
        
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c))
            {
                if (frequency.ContainsKey(c))
                    frequency[c]++;
                else
                    frequency[c] = 1;
            }
        }
        
        // Display results sorted by character
        Console.WriteLine("\nCharacter Frequency:");
        foreach (var kvp in frequency.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}