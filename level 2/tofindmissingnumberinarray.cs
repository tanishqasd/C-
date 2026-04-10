using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of array: ");
        int size = int.Parse(Console.ReadLine());
        
        int[] array = new int[size];
        
        // Read array elements
        Console.WriteLine("Enter array elements (numbers from 1 to " + (size + 1) + "):");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Element {i}: ");
            array[i] = int.Parse(Console.ReadLine());
        }
        
        // Find missing number
        int n = size + 1;
        long expectedSum = (long)n * (n + 1) / 2;
        long actualSum = 0;
        
        foreach (int num in array)
        {
            actualSum += num;
        }
        
        int missingNumber = (int)(expectedSum - actualSum);
        
        // Display result
        Console.WriteLine($"\nMissing number: {missingNumber}");
    }
}