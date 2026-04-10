using System;

class FactorialProgram
{
    static int CalculateFactorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        else
            return n * CalculateFactorial(n - 1);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number < 0)
        {
            Console.WriteLine("Factorial is not defined for negative numbers.");
        }
        else
        {
            int result = CalculateFactorial(number);
            Console.WriteLine($"Factorial of {number} is: {result}");
        }
    }
}