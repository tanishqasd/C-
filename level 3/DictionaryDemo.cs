using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> employees = new Dictionary<int, string>();
        employees.Add(101, "Tanishqa");
        employees.Add(102, "Bob");

        foreach (KeyValuePair<int, string> kvp in employees)
        {
            Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
        }
    }
}