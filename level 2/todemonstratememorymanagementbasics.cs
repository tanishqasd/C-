using System;

class MemoryManagementBasics
{
    static void Main()
    {
        Console.WriteLine("=== Memory Management Basics ===\n");

        // Example 1: Value Types (Stack Memory)
        Console.WriteLine("Example 1: Value Types (Stack)");
        int x = 10;
        int y = x;
        y = 20;
        Console.WriteLine($"x = {x}, y = {y}"); // x remains 10
        Console.WriteLine("Value types are copied, not referenced\n");

        // Example 2: Reference Types (Heap Memory)
        Console.WriteLine("Example 2: Reference Types (Heap)");
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = arr1;
        arr2[0] = 100;
        Console.WriteLine($"arr1[0] = {arr1[0]}, arr2[0] = {arr2[0]}"); // Both are 100
        Console.WriteLine("Reference types share the same memory\n");

        // Example 3: Object and Garbage Collection
        Console.WriteLine("Example 3: Garbage Collection");
        Person p1 = new Person("Alice", 25);
        p1 = null; // Object becomes eligible for garbage collection
        Console.WriteLine("p1 set to null - eligible for GC\n");

        // Example 4: Memory usage with strings
        Console.WriteLine("Example 4: String Immutability");
        string str1 = "Hello";
        string str2 = str1;
        str1 = "World";
        Console.WriteLine($"str1 = {str1}, str2 = {str2}"); // Different values
        Console.WriteLine("Strings are immutable\n");

        // Example 5: Boxing and Unboxing
        Console.WriteLine("Example 5: Boxing and Unboxing");
        int num = 5;
        object box = num; // Boxing - value type to heap
        int unbox = (int)box; // Unboxing - heap to value type
        Console.WriteLine($"Original: {num}, Boxed then Unboxed: {unbox}\n");

        // Force garbage collection (not recommended in production)
        Console.WriteLine("Example 6: Manual GC");
        GC.Collect();
        Console.WriteLine("Garbage Collection triggered");
    }
}

// Reference type example
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine($"Person object created: {Name}");
    }

    ~Person()
    {
        Console.WriteLine($"Person object destroyed: {Name}");
    }
}