using System;

class Program
{
    static void Main()
    {
        // Example 1: Simple do-while loop
        Console.WriteLine("Example 1: Counting from 1 to 5");
        int count = 1;
        do
        {
            Console.WriteLine(count);
            count++;
        } while (count <= 5);

        Console.WriteLine();

        // Example 2: User input validation
        Console.WriteLine("Example 2: User Input Validation");
        int number;
        do
        {
            Console.Write("Enter a number between 1 and 10: ");
            number = int.Parse(Console.ReadLine());
            if (number < 1 || number > 10)
                Console.WriteLine("Invalid input. Try again.");
        } while (number < 1 || number > 10);
        Console.WriteLine($"You entered: {number}");

        Console.WriteLine();

        // Example 3: Menu-driven program
        Console.WriteLine("Example 3: Menu-Driven Program");
        int choice;
        do
        {
            Console.WriteLine("\n1. Add\n2. Subtract\n3. Exit");
            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());
            
            if (choice == 1)
                Console.WriteLine("Selected: Add");
            else if (choice == 2)
                Console.WriteLine("Selected: Subtract");
        } while (choice != 3);

        Console.WriteLine("Program ended.");
    }
}