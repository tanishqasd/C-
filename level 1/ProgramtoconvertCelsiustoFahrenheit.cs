using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());

        double fahrenheit = (celsius * 9 / 5) + 32;

        Console.WriteLine($"{celsius}°C is equal to {fahrenheit}°F");
    }
}