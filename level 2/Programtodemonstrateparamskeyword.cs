using System;

class Program
{
    // Method using params keyword to accept variable number of integers
    static int SumNumbers(params int[] numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    // Method using params with strings
    static void PrintStrings(params string[] strings)
    {
        Console.WriteLine("Strings received:");
        foreach (string str in strings)
        {
            Console.WriteLine($"  - {str}");
        }
    }

    static void Main()
    {
        // Calling SumNumbers with different number of arguments
        Console.WriteLine("Sum of 5, 10, 15: " + SumNumbers(5, 10, 15));
        Console.WriteLine("Sum of 1, 2, 3, 4, 5: " + SumNumbers(1, 2, 3, 4, 5));
        Console.WriteLine("Sum of 100: " + SumNumbers(100));

        Console.WriteLine();

        // Calling PrintStrings with different number of arguments
        PrintStrings("Hello", "World", "C#");
        PrintStrings("One", "Two");
    }
}