using System;

class RecursionDemo
{
    static void Main()
    {
        Console.WriteLine("=== Recursion Demonstrations ===\n");

        // Example 1: Factorial using recursion
        Console.WriteLine("Example 1: Factorial");
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine($"Factorial of {num} = {Factorial(num)}\n");

        // Example 2: Fibonacci using recursion
        Console.WriteLine("Example 2: Fibonacci Series");
        Console.Write("Enter number of terms: ");
        int terms = int.Parse(Console.ReadLine());
        Console.Write("Fibonacci series: ");
        for (int i = 0; i < terms; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
        Console.WriteLine("\n");

        // Example 3: Sum of natural numbers
        Console.WriteLine("Example 3: Sum of Natural Numbers");
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Sum of 1 to {n} = {SumNatural(n)}\n");

        // Example 4: Power calculation
        Console.WriteLine("Example 4: Power Calculation");
        Console.Write("Enter base: ");
        int base_num = int.Parse(Console.ReadLine());
        Console.Write("Enter exponent: ");
        int exp = int.Parse(Console.ReadLine());
        Console.WriteLine($"{base_num}^{exp} = {Power(base_num, exp)}\n");

        // Example 5: Reverse a number
        Console.WriteLine("Example 5: Reverse a Number");
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine($"Reversed: {ReverseNumber(number)}");
    }

    // Factorial: n! = n * (n-1)!
    static int Factorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Factorial(n - 1);
    }

    // Fibonacci: F(n) = F(n-1) + F(n-2)
    static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    // Sum of natural numbers: Sum(n) = n + Sum(n-1)
    static int SumNatural(int n)
    {
        if (n == 0)
            return 0;
        return n + SumNatural(n - 1);
    }

    // Power: base^exp = base * base^(exp-1)
    static int Power(int base_num, int exp)
    {
        if (exp == 0)
            return 1;
        return base_num * Power(base_num, exp - 1);
    }

    // Reverse a number
    static int ReverseNumber(int num)
    {
        return ReverseHelper(num, 0);
    }

    static int ReverseHelper(int num, int reversed)
    {
        if (num == 0)
            return reversed;
        return ReverseHelper(num / 10, reversed * 10 + num % 10);
    }
}