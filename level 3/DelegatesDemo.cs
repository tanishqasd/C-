using System;

class Program
{
    // 1. Declare the delegate
    delegate void PrintMessage(string message);

    static void Main()
    {
        // 2. Instantiate the delegate with a matching method
        PrintMessage printer = ShowToConsole;
        
        // 3. Invoke the delegate
        printer("Hello via Delegate!");
    }

    static void ShowToConsole(string text)
    {
        Console.WriteLine(text);
    }
}