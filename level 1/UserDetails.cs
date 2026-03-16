using System;

class Program
{
    static void Main()
    {
        string name;
        int age;
        string city;

        Console.Write("Enter your name: ");
        name = Console.ReadLine();

        Console.Write("Enter your age: ");
        age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your city: ");
        city = Console.ReadLine();

        Console.WriteLine("\n--- User Details ---");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("City: " + city);
    }
}