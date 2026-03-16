using System;

class Program
{
    static void Main()
    {
        double principal, rate, time, simpleInterest;

        Console.Write("Enter Principal Amount: ");
        principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest: ");
        rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time (in years): ");
        time = Convert.ToDouble(Console.ReadLine());

        simpleInterest = (principal * rate * time) / 100;

        Console.WriteLine("Simple Interest = " + simpleInterest);
    }
}