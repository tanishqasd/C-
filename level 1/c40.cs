using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }
        
        Console.WriteLine($"Sum of first {n} natural numbers: {sum}");
    }
}