using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a character: ");
        char ch = Console.ReadLine()[0];
        
        int asciiValue = (int)ch;
        
        Console.WriteLine($"ASCII value of '{ch}' is: {asciiValue}");
    }
}