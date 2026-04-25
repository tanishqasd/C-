using System;

namespace VirtualOverrideDemo
{
    // ==========================================================
    // 1. THE BASE CLASS
    // ==========================================================
    class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public Employee(string name, double baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        // The 'virtual' keyword grants permission for child classes 
        // to replace this specific method's logic.
        public virtual void CalculateBonus()
        {
            double bonus = BaseSalary * 0.05; // Standard 5% bonus
            Console.WriteLine($"[Standard Employee] {Name} earned a bonus of: ${bonus}");
        }
    }

    // ==========================================================
    // 2. THE DERIVED CLASS
    // ==========================================================
    class Executive : Employee
    {
        // Passing data up to the parent constructor
        public Executive(string name, double baseSalary) : base(name, baseSalary) 
        { 
        }

        // The 'override' keyword tells the compiler we are explicitly 
        // replacing the parent's virtual method with our own rule.
        public override void CalculateBonus()
        {
            double bonus = BaseSalary * 0.20; // Executive 20% bonus
            Console.WriteLine($"[Executive] {Name} earned a bonus of: ${bonus}");
        }
    }

    // ==========================================================
    // MAIN EXECUTION
    // ==========================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Virtual & Override Demo ---\n");

            // 1. Standard Object Behavior
            Employee regularWorker = new Employee("Tanishqa", 50000);
            regularWorker.CalculateBonus();

            Executive topManager = new Executive("Alice", 120000);
            topManager.CalculateBonus();

            Console.WriteLine("\n--- The True Power of Virtual/Override ---");

            // 2. The magic happens when we store a Child object in a Parent variable!
            // Even though the variable type is 'Employee', the C# runtime looks at the 
            // ACTUAL object in memory (an Executive). Because the method was marked 
            // virtual/override, it knows to run the Executive's 20% bonus logic!
            
            Employee hiddenExecutive = new Executive("Bob", 100000);
            hiddenExecutive.CalculateBonus(); 

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}