using System;

class BreakAndContinueDemo
{
    static void Main()
    {
        Console.WriteLine("=== BREAK Statement Demo ===");
        Console.WriteLine("Print numbers 1 to 5, stop at 3:\n");
        
        for (int i = 1; i <= 10; i++)
        {
            if (i == 3)
                break; // Exit loop when i equals 3
            
            Console.WriteLine(i);
        }
        
        Console.WriteLine("\n=== CONTINUE Statement Demo ===");
        Console.WriteLine("Print numbers 1 to 5, skip 3:\n");
        
        for (int i = 1; i <= 5; i++)
        {
            if (i == 3)
                continue; // Skip current iteration when i equals 3
            
            Console.WriteLine(i);
        }
        
        Console.WriteLine("\n=== Combined Example ===");
        Console.WriteLine("Sum numbers 1 to 10, skip evens and stop at 8:\n");
        
        int sum = 0;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 8)
                break; // Exit when i equals 8
            
            if (i % 2 == 0)
                continue; // Skip even numbers
            
            sum += i;
            Console.WriteLine($"Added {i}, Sum: {sum}");
        }
    }
}