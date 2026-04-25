using System;

class Program
{
    static void Main()
    {
        try
        {
            int result = 10 / 0;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Cleanup: Finally block always executes.");
        }
    }
}