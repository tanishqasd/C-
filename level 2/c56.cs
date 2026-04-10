using System;

class MergeArrays
{
    static void Main()
    {
        int[] array1 = { 1, 3, 5, 7 };
        int[] array2 = { 2, 4, 6, 8 };
        
        int[] merged = new int[array1.Length + array2.Length];
        
        Array.Copy(array1, 0, merged, 0, array1.Length);
        Array.Copy(array2, 0, merged, array1.Length, array2.Length);
        
        Console.WriteLine("Merged Array:");
        foreach (int num in merged)
        {
            Console.Write(num + " ");
        }
    }
}