using System;

namespace ConstructorDemo
{
    // ==========================================================
    // THE CLASS
    // ==========================================================
    class ConstructionProject
    {
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public double Budget { get; set; }

        // 1. DEFAULT CONSTRUCTOR (Takes no parameters)
        // Used when we don't have the details yet, but need to create the object safely.
        public ConstructionProject()
        {
            ProjectName = "TBD (To Be Determined)";
            Status = "Pending Approval";
            Budget = 0.0;
            Console.WriteLine("[Log] Default constructor triggered: Blank project initialized.");
        }

        // 2. PARAMETERIZED CONSTRUCTOR (Takes specific arguments)
        // Used when we have the necessary data upfront to fully configure the object.
        public ConstructionProject(string projectName, double initialBudget)
        {
            ProjectName = projectName;
            Status = "Active Phase 1";
            Budget = initialBudget;
            Console.WriteLine($"[Log] Parameterized constructor triggered: '{ProjectName}' initialized.");
        }

        public void DisplayProjectBrief()
        {
            Console.WriteLine($"-> Project: {ProjectName} | Status: {Status} | Budget: ${Budget}");
        }
    }

    // ==========================================================
    // MAIN EXECUTION
    // ==========================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Constructor Demo ---\n");

            // SCENARIO A: Creating an object without passing any data.
            // The compiler looks for and runs the Default Constructor automatically.
            Console.WriteLine("Creating Project 1:");
            ConstructionProject futureProject = new ConstructionProject();
            futureProject.DisplayProjectBrief();

            Console.WriteLine("\n-----------------------------------\n");

            // SCENARIO B: Creating an object and passing data inside the parentheses.
            // The compiler looks for and runs the Parameterized Constructor automatically.
            Console.WriteLine("Creating Project 2:");
            ConstructionProject highwayProject = new ConstructionProject("Highway Expansion Route 4", 15000000);
            highwayProject.DisplayProjectBrief();

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}