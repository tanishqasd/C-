using System;

class Program
{
    static void Main()
    {
        try
        {
            CheckAge(15);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught manually thrown exception: {ex.Message}");
        }
    }

    static void CheckAge(int age)
    {
        if (age < 18)
        {
            // Throwing a custom or built-in exception manually
            throw new ArgumentException("Age must be 18 or older to proceed.");
        }
    }
}