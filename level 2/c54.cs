using System;

class Program
{
    static void Main()
    {
        // Declare and initialize an array
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Original Array:");
        DisplayArray(arr);

        // Sort the array
        Array.Sort(arr);

        Console.WriteLine("\nSorted Array:");
        DisplayArray(arr);
    }

    static void DisplayArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}