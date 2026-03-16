using System;

class Program
{
    static void Main()
    {
        int number, count = 0;

        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                count++;
            }
        }

        if (count == 2)
        {
            Console.WriteLine("The number is a Prime Number");
        }
        else
        {
            Console.WriteLine("The number is not a Prime Number");
        }
    }
}