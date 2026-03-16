using System;

class Program
{
    static void Main()
    {
        int number, remainder, result = 0, original;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        original = number;

        while (number != 0)
        {
            remainder = number % 10;
            result += remainder * remainder * remainder;
            number /= 10;
        }

        if (result == original)
        {
            Console.WriteLine("The number is an Armstrong number");
        }
        else
        {
            Console.WriteLine("The number is not an Armstrong number");
        }
    }
}