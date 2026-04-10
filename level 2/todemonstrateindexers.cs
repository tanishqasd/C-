using System;

class IndexerDemo
{
    static void Main()
    {
        Console.WriteLine("=== Indexer Demonstration ===\n");

        // Example 1: Simple indexer with array
        Console.WriteLine("Example 1: Simple Indexer");
        StudentGrades grades = new StudentGrades();
        grades[0] = 95;
        grades[1] = 87;
        grades[2] = 92;
        Console.WriteLine($"Grade at index 0: {grades[0]}");
        Console.WriteLine($"Grade at index 1: {grades[1]}");
        Console.WriteLine($"Grade at index 2: {grades[2]}\n");

        // Example 2: String indexer (dictionary-like)
        Console.WriteLine("Example 2: String Indexer");
        StudentData student = new StudentData();
        student["Alice"] = "Engineering";
        student["Bob"] = "Sales";
        student["Charlie"] = "Marketing";
        Console.WriteLine($"Alice's Department: {student["Alice"]}");
        Console.WriteLine($"Bob's Department: {student["Bob"]}\n");

        // Example 3: Indexer with validation
        Console.WriteLine("Example 3: Indexer with Validation");
        TemperatureData temps = new TemperatureData();
        temps[0] = 25;
        temps[1] = 30;
        temps[2] = 28;
        Console.WriteLine($"Temperature at index 0: {temps[0]}°C");
        Console.WriteLine($"Temperature at index 1: {temps[1]}°C");
    }
}

// Example 1: Simple integer indexer
class StudentGrades
{
    private int[] grades = new int[10];

    public int this[int index]
    {
        get { return grades[index]; }
        set { grades[index] = value; }
    }
}

// Example 2: String indexer (dictionary-like)
class StudentData
{
    private System.Collections.Hashtable data = new System.Collections.Hashtable();

    public string this[string key]
    {
        get { return (string)data[key]; }
        set { data[key] = value; }
    }
}

// Example 3: Indexer with validation
class TemperatureData
{
    private double[] temperatures = new double[10];

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= temperatures.Length)
            {
                Console.WriteLine("Invalid index!");
                return 0;
            }
            return temperatures[index];
        }
        set
        {
            if (index >= 0 && index < temperatures.Length)
                temperatures[index] = value;
        }
    }
}