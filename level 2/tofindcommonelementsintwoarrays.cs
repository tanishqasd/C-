using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 3, 4, 5, 6, 7 };

        // Find common elements
        var commonElements = array1.Intersect(array2);

        Console.WriteLine("Common elements:");
        foreach (var element in commonElements)
        {
            Console.WriteLine(element);
        }
    }
}