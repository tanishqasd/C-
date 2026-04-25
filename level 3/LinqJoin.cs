using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var students = new[] { new { Id = 1, Name = "Tanishqa" }, new { Id = 2, Name = "John" } };
        var courses = new[] { new { StudentId = 1, Course = "MBA" }, new { StudentId = 2, Course = "B.Tech" } };

        var query = students.Join(courses, 
                                  s => s.Id, 
                                  c => c.StudentId, 
                                  (s, c) => new { s.Name, c.Course });

        foreach (var item in query)
        {
            Console.WriteLine($"{item.Name} is enrolled in {item.Course}");
        }
    }
}