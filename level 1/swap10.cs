using System;

class Program
{
    static void Main()
    {
        int num1, num2, temp;

        Console.Write("Enter first number: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        // Swapping
        temp = num1;
        num1 = num2;
        num2 = temp;

        Console.WriteLine("After swapping:");
        Console.WriteLine("First number: " + num1);
        Console.WriteLine("Second number: " + num2);
    }
}