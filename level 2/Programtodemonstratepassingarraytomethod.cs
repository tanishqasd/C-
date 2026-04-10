using System;

class ArrayPassingDemo
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        
        Console.WriteLine("Original array:");
        DisplayArray(numbers);
        
        // Modify array through method
        DoubleArrayElements(numbers);
        
        Console.WriteLine("\nArray after doubling elements:");
        DisplayArray(numbers);
        
        // Calculate sum
        int sum = CalculateSum(numbers);
        Console.WriteLine($"\nSum of array elements: {sum}");
        
        // Find maximum
        int max = FindMax(numbers);
        Console.WriteLine($"Maximum element: {max}");
    }
    
    // Method to display array
    static void DisplayArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
    
    // Method to modify array elements
    static void DoubleArrayElements(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i] * 2;
        }
    }
    
    // Method to calculate sum
    static int CalculateSum(int[] arr)
    {
        int sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }
        return sum;
    }
    
    // Method to find maximum element
    static int FindMax(int[] arr)
    {
        int max = arr[0];
        foreach (int num in arr)
        {
            if (num > max)
                max = num;
        }
        return max;
    }
}