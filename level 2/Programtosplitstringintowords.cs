using System;

class Program
{
    static void Main()
    {
        string sentence = "Hello World from C Sharp";
        
        // Split string into words
        string[] words = sentence.Split(' ');
        
        Console.WriteLine("Words in the string:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}