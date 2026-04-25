using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        uniqueNumbers.Add(1);
        uniqueNumbers.Add(2);
        uniqueNumbers.Add(1); // Ignored, as HashSets only store unique values

        Console.WriteLine($"Count of numbers: {uniqueNumbers.Count}"); // Outputs 2
    }
}