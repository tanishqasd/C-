using System;

class ConditionalStatementsDemo
{
    static void Main()
    {
        // If-Else Statement
        int age = 18;
        if (age >= 18)
        {
            Console.WriteLine("You are an adult.");
        }
        else
        {
            Console.WriteLine("You are a minor.");
        }

        // If-Else If-Else Statement
        int marks = 75;
        if (marks >= 90)
        {
            Console.WriteLine("Grade: A");
        }
        else if (marks >= 80)
        {
            Console.WriteLine("Grade: B");
        }
        else if (marks >= 70)
        {
            Console.WriteLine("Grade: C");
        }
        else
        {
            Console.WriteLine("Grade: F");
        }

        // Switch Statement
        int day = 3;
        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            default:
                Console.WriteLine("Invalid day");
                break;
        }

        // Ternary Operator
        int number = 10;
        string result = (number % 2 == 0) ? "Even" : "Odd";
        Console.WriteLine($"Number {number} is {result}");
    }
}