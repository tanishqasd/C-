using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter total number of days: ");
        int totalDays = int.Parse(Console.ReadLine());

        int years = totalDays / 365;
        int remainingDays = totalDays % 365;
        int months = remainingDays / 30;
        int days = remainingDays % 30;

        Console.WriteLine($"\n{totalDays} days = {years} years, {months} months, {days} days");
    }
}