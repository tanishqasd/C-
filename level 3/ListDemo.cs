using System;
using System.Collections.Generic; // Required for generic List<T>

class Program
{
    static void Main()
    {
        List<string> names = new List<string>();
        names.Add("Tanishqa");
        names.Add("Alice");

        // Type-safe: names.Add(10); would cause a compile error
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}