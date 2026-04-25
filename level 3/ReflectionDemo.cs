using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Inspecting the string class at runtime
        Type type = typeof(string);
        Console.WriteLine($"Type Name: {type.Name}");

        Console.WriteLine("Some Methods available in String:");
        MethodInfo[] methods = type.GetMethods();
        
        for (int i = 0; i < 5; i++) // Just printing first 5
        {
            Console.WriteLine($" - {methods[i].Name}");
        }
    }
}