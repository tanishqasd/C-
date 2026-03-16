using System;

class Program
{
    static void Main()
    {
        int number;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine("The number is Even");
        }
        else
        {
            Console.WriteLine("The number is Odd");
        }
    }
}