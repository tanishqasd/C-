using System;

class Program
{
    static void Main()
    {
        int number, sum = 0, remainder;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        while (number != 0)
        {
            remainder = number % 10;
            sum = sum + remainder;
            number = number / 10;
        }

        Console.WriteLine("Sum of digits = " + sum);
    }
}