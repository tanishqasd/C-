using System;

class DateTimeDemo
{
    static void Main()
    {
        // Current date and time
        DateTime now = DateTime.Now;
        Console.WriteLine("Current Date and Time: " + now);

        // Current UTC date and time
        DateTime utcNow = DateTime.UtcNow;
        Console.WriteLine("UTC Date and Time: " + utcNow);

        // Create specific date
        DateTime specificDate = new DateTime(2024, 12, 25);
        Console.WriteLine("Specific Date: " + specificDate);

        // Create date with time
        DateTime dateTime = new DateTime(2024, 12, 25, 15, 30, 45);
        Console.WriteLine("Date with Time: " + dateTime);

        // Date properties
        Console.WriteLine("\nDate Properties:");
        Console.WriteLine("Year: " + now.Year);
        Console.WriteLine("Month: " + now.Month);
        Console.WriteLine("Day: " + now.Day);
        Console.WriteLine("Hour: " + now.Hour);
        Console.WriteLine("Minute: " + now.Minute);
        Console.WriteLine("Second: " + now.Second);
        Console.WriteLine("DayOfWeek: " + now.DayOfWeek);

        // Date arithmetic
        DateTime tomorrow = now.AddDays(1);
        DateTime nextMonth = now.AddMonths(1);
        Console.WriteLine("\nDate Arithmetic:");
        Console.WriteLine("Tomorrow: " + tomorrow);
        Console.WriteLine("Next Month: " + nextMonth);

        // Date comparison
        DateTime date1 = new DateTime(2024, 1, 1);
        DateTime date2 = new DateTime(2024, 12, 31);
        Console.WriteLine("\nDate Comparison:");
        Console.WriteLine("date1 < date2: " + (date1 < date2));

        // TimeSpan - difference between dates
        TimeSpan difference = date2 - date1;
        Console.WriteLine("Days between dates: " + difference.Days);
    }
}