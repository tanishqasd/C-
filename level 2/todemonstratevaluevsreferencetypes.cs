using System;

class Program
{
    // Value type (struct)
    struct Point
    {
        public int X;
        public int Y;
    }

    // Reference type (class)
    class Person
    {
        public string Name;
        public int Age;
    }

    static void Main()
    {
        // VALUE TYPE DEMONSTRATION
        Console.WriteLine("=== Value Types ===");
        Point p1 = new Point { X = 10, Y = 20 };
        Point p2 = p1;  // Copy of value
        p2.X = 30;
        
        Console.WriteLine($"p1.X: {p1.X}");  // 10 (unchanged)
        Console.WriteLine($"p2.X: {p2.X}");  // 30

        // REFERENCE TYPE DEMONSTRATION
        Console.WriteLine("\n=== Reference Types ===");
        Person person1 = new Person { Name = "Alice", Age = 25 };
        Person person2 = person1;  // Reference to same object
        person2.Name = "Bob";
        
        Console.WriteLine($"person1.Name: {person1.Name}");  // Bob (changed)
        Console.WriteLine($"person2.Name: {person2.Name}");  // Bob
    }
}