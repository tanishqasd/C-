using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        
        string reversed = ReverseString(input);
        
        Console.WriteLine("Reversed string: " + reversed);
    }
    
    static string ReverseString(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}