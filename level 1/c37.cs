using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter base number: ");
        double baseNum = double.Parse(Console.ReadLine());

        Console.Write("Enter exponent: ");
        double exponent = double.Parse(Console.ReadLine());

        double result = Math.Pow(baseNum, exponent);

        Console.WriteLine($"{baseNum} raised to the power {exponent} = {result}");
    }
}