using System;

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
        
        // Display array elements
        Console.WriteLine("\nArray elements are:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}