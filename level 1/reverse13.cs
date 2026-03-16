using System;

class Program
{
    static void Main()
    {
        int number, reverse = 0, remainder;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        while (number != 0)
        {
            remainder = number % 10;
            reverse = reverse * 10 + remainder;
            number = number / 10;
        }

        Console.WriteLine("Reversed number is: " + reverse);
    }
}