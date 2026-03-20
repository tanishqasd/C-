using System;

class TupleDemo
{
    static void Main()
    {
        // Basic tuple
        var person = ("Alice", 30, "Engineer");
        Console.WriteLine($"Name: {person.Item1}, Age: {person.Item2}, Job: {person.Item3}");

        // Named tuple elements
        var employee = (Name: "Bob", Age: 25, Department: "Sales");
        Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}, Department: {employee.Department}");

        // Tuple with different types
        var mixed = (id: 101, isActive: true, salary: 50000.50);
        Console.WriteLine($"ID: {mixed.id}, Active: {mixed.isActive}, Salary: {mixed.salary}");

        // Returning multiple values from method
        var (x, y) = GetCoordinates();
        Console.WriteLine($"Coordinates: X={x}, Y={y}");

        // Tuple deconstruction
        (string name, int age) = ("Charlie", 35);
        Console.WriteLine($"Name: {name}, Age: {age}");
    }

    static (int, int) GetCoordinates()
    {
        return (10, 20);
    }
}