using System;

class Program
{
    static void Main()
    {
        int number, count = 0;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        while (number != 0)
        {
            number = number / 10;
            count++;
        }

        Console.WriteLine("Total number of digits = " + count);
    }
}