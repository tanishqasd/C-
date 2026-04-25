using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        
        // Accumulates values (1*2*3*4*5)
        int product = numbers.Aggregate((total, next) => total * next);
        
        Console.WriteLine($"Product: {product}"); // Outputs: 120
    }
}