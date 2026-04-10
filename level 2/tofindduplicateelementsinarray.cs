using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of array: ");
        int size = int.Parse(Console.ReadLine());
        
        int[] array = new int[size];
        
        // Read array elements
        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Element {i}: ");
            array[i] = int.Parse(Console.ReadLine());
        }
        
        // Find duplicate elements
        Console.WriteLine("\nDuplicate elements:");
        HashSet<int> seen = new HashSet<int>();
        HashSet<int> duplicates = new HashSet<int>();
        
        foreach (int num in array)
        {
            if (seen.Contains(num))
            {
                duplicates.Add(num);
            }
            else
            {
                seen.Add(num);
            }
        }
        
        if (duplicates.Count == 0)
        {
            Console.WriteLine("No duplicate elements found");
        }
        else
        {
            foreach (int dup in duplicates.OrderBy(x => x))
            {
                Console.WriteLine(dup);
            }
        }
    }
}