using System;

class WhileLoopDemo
{
    static void Main()
    {
        // Example 1: Simple counter
        Console.WriteLine("Example 1: Counting from 1 to 5");
        int count = 1;
        while (count <= 5)
        {
            Console.WriteLine($"Count: {count}");
            count++;
        }

        // Example 2: Sum of numbers
        Console.WriteLine("\nExample 2: Sum of numbers 1 to 10");
        int num = 1;
        int sum = 0;
        while (num <= 10)
        {
            sum += num;
            num++;
        }
        Console.WriteLine($"Sum: {sum}");

        // Example 3: User input validation
        Console.WriteLine("\nExample 3: Input validation");
        int age = 0;
        while (age <= 0 || age > 150)
        {
            Console.Write("Enter your age (1-150): ");
            age = int.Parse(Console.ReadLine());
        }
        Console.WriteLine($"Your age is: {age}");
    }
}