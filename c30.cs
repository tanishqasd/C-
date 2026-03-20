using System;

class SwitchCaseDemo
{
    static void Main()
    {
        Console.WriteLine("=== Switch-Case Demonstration ===\n");

        // Example 1: Simple switch-case with integers
        Console.WriteLine("Example 1: Day of Week");
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
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day");
                break;
        }

        // Example 2: Switch-case with strings
        Console.WriteLine("\nExample 2: Fruit Selection");
        string fruit = "apple";
        switch (fruit.ToLower())
        {
            case "apple":
                Console.WriteLine("Red fruit");
                break;
            case "banana":
                Console.WriteLine("Yellow fruit");
                break;
            case "orange":
                Console.WriteLine("Orange colored fruit");
                break;
            default:
                Console.WriteLine("Unknown fruit");
                break;
        }

        // Example 3: Switch-case with character grades
        Console.WriteLine("\nExample 3: Grade Assignment");
        char grade = 'B';
        switch (grade)
        {
            case 'A':
                Console.WriteLine("Excellent");
                break;
            case 'B':
                Console.WriteLine("Good");
                break;
            case 'C':
                Console.WriteLine("Average");
                break;
            case 'D':
                Console.WriteLine("Below Average");
                break;
            case 'F':
                Console.WriteLine("Fail");
                break;
            default:
                Console.WriteLine("Invalid grade");
                break;
        }
    }
}