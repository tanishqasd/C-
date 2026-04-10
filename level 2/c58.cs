using System;

class SearchElement
{
    static void Main()
    {
        // Create an array
        int[] array = { 10, 25, 30, 45, 50, 65, 80, 95 };
        
        // Element to search
        Console.Write("Enter element to search: ");
        int searchElement = int.Parse(Console.ReadLine());
        
        // Search for the element
        int index = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == searchElement)
            {
                index = i;
                break;
            }
        }
        
        // Display result
        if (index != -1)
        {
            Console.WriteLine($"Element found at index: {index}");
        }
        else
        {
            Console.WriteLine("Element not found in array");
        }
    }
}
