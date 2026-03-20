using System;

class StudentGradeCalculator
{
    static void Main()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter marks (0-100): ");
        int marks = int.Parse(Console.ReadLine());
        
        string grade = CalculateGrade(marks);
        
        Console.WriteLine($"\nStudent: {name}");
        Console.WriteLine($"Marks: {marks}");
        Console.WriteLine($"Grade: {grade}");
    }
    
    static string CalculateGrade(int marks)
    {
        if (marks >= 90)
            return "A";
        else if (marks >= 80)
            return "B";
        else if (marks >= 70)
            return "C";
        else if (marks >= 60)
            return "D";
        else if (marks >= 50)
            return "E";
        else
            return "F";
    }
}