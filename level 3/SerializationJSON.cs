using System;
using System.Text.Json;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Person p = new Person { Name = "Tanishqa", Age = 21 };

        // Serialize Object to JSON
        string jsonString = JsonSerializer.Serialize(p);
        Console.WriteLine($"Serialized: {jsonString}");

        // Deserialize JSON to Object
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine($"Deserialized: Name={deserializedPerson.Name}, Age={deserializedPerson.Age}");
    }
}