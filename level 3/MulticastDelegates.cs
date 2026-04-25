using System;

class Program
{
    delegate void Notify();

    static void Main()
    {
        Notify myDelegate = Task1;
        myDelegate += Task2; // Adding a second method

        Console.WriteLine("Invoking multicast delegate:");
        myDelegate(); // Calls both Task1 and Task2
    }

    static void Task1() => Console.WriteLine("Task 1 executed.");
    static void Task2() => Console.WriteLine("Task 2 executed.");
}