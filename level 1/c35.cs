using System;

class Program
{
    static void Main()
    {
        int n = 5;
        
        // Print upper triangle
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
        
        // Print lower triangle
        for (int i = n - 1; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}