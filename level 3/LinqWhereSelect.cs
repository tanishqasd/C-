using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        // Where filters, Select transforms
        var squaredEvens = numbers.Where(n => n % 2 == 0)
                                  .Select(n => n * n);

        Console.WriteLine(string.Join(", ", squaredEvens)); // Outputs: 4, 16, 36
    }
}