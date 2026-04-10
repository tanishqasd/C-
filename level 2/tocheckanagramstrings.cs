using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();
        
        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();
        
        if (AreAnagrams(str1, str2))
        {
            Console.WriteLine("The strings are anagrams.");
        }
        else
        {
            Console.WriteLine("The strings are not anagrams.");
        }
    }
    
    static bool AreAnagrams(string str1, string str2)
    {
        // Remove spaces and convert to lowercase
        str1 = str1.Replace(" ", "").ToLower();
        str2 = str2.Replace(" ", "").ToLower();
        
        // Check if lengths are equal
        if (str1.Length != str2.Length)
            return false;
        
        // Sort characters and compare
        string sorted1 = string.Concat(str1.OrderBy(c => c));
        string sorted2 = string.Concat(str2.OrderBy(c => c));
        
        return sorted1 == sorted2;
    }
}