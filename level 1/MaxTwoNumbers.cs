using System;

class Program
{
    static void Main()
    {
        int num1, num2;

        Console.Write("Enter first number: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        if (num1 > num2)
        {
            Console.WriteLine("Maximum number is: " + num1);
        }
        else
        {
            Console.WriteLine("Maximum number is: " + num2);
        }
    }
}