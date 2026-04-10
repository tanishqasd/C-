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
        
        // Find second largest element
        int largest = int.MinValue;
        int secondLargest = int.MinValue;
        
        foreach (int num in array)
        {
            if (num > largest)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest && num != largest)
            {
                secondLargest = num;
            }
        }
        
        // Display result
        if (secondLargest == int.MinValue)
        {
            Console.WriteLine("Second largest element does not exist");
        }
        else
        {
            Console.WriteLine($"Second largest element: {secondLargest}");
        }
    }
}