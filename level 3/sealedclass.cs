using System;

namespace SealedClassDemo
{
    // ==========================================================
    // 1. THE BASE CLASS
    // ==========================================================
    class Employee
    {
        public string Name { get; set; }

        public virtual void DisplayRole()
        {
            Console.WriteLine($"{Name} is a standard employee.");
        }
    }

    // ==========================================================
    // 2. THE SEALED CLASS
    // ==========================================================
    // The 'sealed' keyword prevents any further inheritance.
    // This is the absolute end of this specific inheritance chain.
    sealed class SystemAdministrator : Employee
    {
        public string AdminLevel { get; set; }

        public override void DisplayRole()
        {
            Console.WriteLine($"{Name} is a System Administrator with {AdminLevel} access.");
        }

        public void ResetPasswords()
        {
            Console.WriteLine($"[{Name}] executing global password reset...");
        }
    }

    // ==========================================================
    // 3. THE FAILED INHERITANCE ATTEMPT
    // ==========================================================
    // ERROR: If you uncomment the class below, the program WILL NOT compile.
    // The compiler will throw: "cannot derive from sealed type 'SystemAdministrator'"
    
    /*
    class SuperAdmin : SystemAdministrator 
    {
        // This code is illegal in C# because SystemAdministrator is sealed.
    }
    */

    // ==========================================================
    // MAIN EXECUTION
    // ==========================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Sealed Class Demo ---\n");

            // Using the base class
            Employee standardUser = new Employee { Name = "John Doe" };
            standardUser.DisplayRole();

            Console.WriteLine();

            // Using the sealed class
            SystemAdministrator adminUser = new SystemAdministrator 
            { 
                Name = "Tanishqa", 
                AdminLevel = "Tier-0" 
            };
            
            adminUser.DisplayRole();
            adminUser.ResetPasswords();

            Console.WriteLine("\n[Note: Any attempt to inherit from SystemAdministrator is blocked by the compiler.]");
            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}