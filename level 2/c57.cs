using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] array = { 1, 2, 2, 3, 4, 4, 5, 6, 6, 7 };
        
        Console.WriteLine("Original array:");
        Console.WriteLine(string.Join(", ", array));
        
        // Remove duplicates using Distinct()
        int[] uniqueArray = array.Distinct().ToArray();
        
        Console.WriteLine("\nArray after removing duplicates:");
        Console.WriteLine(string.Join(", ", uniqueArray));
    }
}