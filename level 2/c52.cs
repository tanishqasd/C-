using System;

class Program
{
    static void Main()
    {
        int[] array = { 45, 23, 89, 12, 56, 34, 78, 5 };
        
        int largest = array[0];
        int smallest = array[0];
        
        foreach (int num in array)
        {
            if (num > largest)
                largest = num;
            
            if (num < smallest)
                smallest = num;
        }
        
        Console.WriteLine($"Largest element: {largest}");
        Console.WriteLine($"Smallest element: {smallest}");
    }
}