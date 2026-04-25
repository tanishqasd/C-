using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }
}

class Program
{
    static List<Student> students = new List<Student>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Add Student | 2. View All | 3. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();
            if (choice == "1") AddStudent();
            else if (choice == "2") ViewStudents();
            else if (choice == "3") break;
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Course: ");
        string course = Console.ReadLine();

        students.Add(new Student { Id = nextId++, Name = name, Course = course });
        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        if (!students.Any()) { Console.WriteLine("No students found."); return; }
        foreach (var s in students)
            Console.WriteLine($"[ID: {s.Id}] {s.Name} - {s.Course}");
    }
}