using System;

// Define a struct
public struct Person
{
    public string Name;
    public int Age;
    public double Height;

    // Constructor
    public Person(string name, int age, double height)
    {
        Name = name;
        Age = age;
        Height = height;
    }

    // Method
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Height: {Height}m");
    }
}

class Program
{
    static void Main()
    {
        // Create struct instances
        Person p1 = new Person("Alice", 25, 5.6);
        Person p2 = new Person("Bob", 30, 6.1);

        // Access and display
        p1.DisplayInfo();
        p2.DisplayInfo();

        // Modify struct member
        p1.Age = 26;
        Console.WriteLine($"\nUpdated Age: {p1.Age}");

        // Structs are value types - changes don't affect original
        Person p3 = p1;
        p3.Name = "Charlie";
        Console.WriteLine($"p1 Name: {p1.Name}, p3 Name: {p3.Name}");
    }
}