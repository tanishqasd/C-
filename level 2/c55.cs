using System;

class Program
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        
        Console.WriteLine("Original array:");
        PrintArray(array);
        
        ReverseArray(array);
        
        Console.WriteLine("Reversed array:");
        PrintArray(array);
    }
    
    static void ReverseArray(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        
        while (left < right)
        {
            // Swap elements
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            
            left++;
            right--;
        }
    }
    
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}