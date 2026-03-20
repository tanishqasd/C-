using System;

class Program
{
    static void Main()
    {
        // For loop example 1: Print numbers 1 to 10
        Console.WriteLine("Numbers from 1 to 10:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
        }

        // For loop example 2: Print even numbers
        Console.WriteLine("\nEven numbers from 2 to 20:");
        for (int i = 2; i <= 20; i += 2)
        {
            Console.WriteLine(i);
        }

        // For loop example 3: Countdown
        Console.WriteLine("\nCountdown from 5:");
        for (int i = 5; i >= 1; i--)
        {
            Console.WriteLine(i);
        }

        // For loop example 4: Multiplication table
        Console.WriteLine("\nMultiplication table of 5:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"5 × {i} = {5 * i}");
        }

        // For loop example 5: Nested loops
        Console.WriteLine("\nNested loops (3×3 grid):");
        for (int row = 1; row <= 3; row++)
        {
            for (int col = 1; col <= 3; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}