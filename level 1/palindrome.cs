using System;

class Program
{
    static void Main()
    {
        int number, reverse = 0, remainder, original;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        original = number;

        while (number != 0)
        {
            remainder = number % 10;
            reverse = reverse * 10 + remainder;
            number = number / 10;
        }

        if (original == reverse)
        {
            Console.WriteLine("The number is a Palindrome");
        }
        else
        {
            Console.WriteLine("The number is not a Palindrome");
        }
    }
}