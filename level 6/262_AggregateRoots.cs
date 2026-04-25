using System;
using System.Collections.Generic;

namespace Level5_DDD
{
    // 262. Aggregate Roots and Entities.
    // An Aggregate Root is the "Entry Point" to a cluster of related objects.
    // You cannot modify a 'Task' directly; you must go through the 'Project' Aggregate Root.

    public class ConstructionProject // Aggregate Root
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private readonly List<ProjectTask> _tasks = new();

        public ConstructionProject(int id, string name) => (Id, Name) = (id, name);

        public void AddTask(string description)
        {
            // Business Rule: A project cannot have more than 50 active tasks
            if (_tasks.Count >= 50) throw new InvalidOperationException("Project capacity reached.");
            _tasks.Add(new ProjectTask(description));
        }
    }

    public class ProjectTask // Entity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Description { get; set; }
        internal ProjectTask(string desc) => Description = desc;
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- DDD: Aggregate Roots ---");
            var project = new ConstructionProject(1, "Site Alpha Foundation");
            project.AddTask("Excavation");
            Console.WriteLine("Task added via Aggregate Root ensuring business rules were met.");
        }
    }
}