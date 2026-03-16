using System;

class Program
{
    static void Main()
    {
        double principal, rate, time, compoundInterest, amount;

        Console.Write("Enter Principal Amount: ");
        principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest: ");
        rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time (in years): ");
        time = Convert.ToDouble(Console.ReadLine());

        amount = principal * Math.Pow((1 + rate / 100), time);
        compoundInterest = amount - principal;

        Console.WriteLine("Compound Interest = " + compoundInterest);
    }
}