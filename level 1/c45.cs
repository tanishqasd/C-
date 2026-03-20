using System;

// Define an enum for days of the week
enum Day
{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7
}

// Define an enum for colors
enum Color
{
    Red,
    Green,
    Blue,
    Yellow
}

class Program
{
    static void Main()
    {
        // Using enum variable
        Day today = Day.Wednesday;
        Console.WriteLine($"Today is: {today}");
        Console.WriteLine($"Day number: {(int)today}");

        // Iterating through enum values
        Console.WriteLine("\nAll days of the week:");
        foreach (Day day in Enum.GetValues(typeof(Day)))
        {
            Console.WriteLine($"{day} = {(int)day}");
        }

        // Using enum in switch statement
        Color myColor = Color.Blue;
        Console.WriteLine($"\nYou selected: {myColor}");
        
        switch (myColor)
        {
            case Color.Red:
                Console.WriteLine("Color is Red");
                break;
            case Color.Blue:
                Console.WriteLine("Color is Blue");
                break;
            default:
                Console.WriteLine("Other color");
                break;
        }

        // Parsing enum from string
        string dayName = "Friday";
        if (Enum.TryParse(dayName, out Day parsedDay))
        {
            Console.WriteLine($"\nParsed day: {parsedDay}");
        }
    }
}