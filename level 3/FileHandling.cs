using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "demo.txt";

        // Write to file
        File.WriteAllText(filePath, "Hello, File System!");
        Console.WriteLine("Data written to file.");

        // Read from file
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"Read from file: {content}");
        }
    }
}