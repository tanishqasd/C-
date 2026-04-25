using System;

namespace ClassAndObjectDemo
{
    // ==========================================================
    // 1. THE CLASS (The Blueprint)
    // ==========================================================
    class Laptop
    {
        // Properties (The Data / State of the object)
        public string Brand { get; set; }
        public string Model { get; set; }
        public int RamGB { get; set; }

        // Methods (The Behaviors / Actions the object can perform)
        public void PowerOn()
        {
            Console.WriteLine($"The {Brand} {Model} is powering on... Welcome!");
        }

        public void DisplaySpecs()
        {
            Console.WriteLine($"Specifications: {Brand} {Model} configured with {RamGB}GB RAM.");
        }
    }

    // ==========================================================
    // MAIN EXECUTION
    // ==========================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Class and Object Demo ---\n");

            // ==========================================================
            // 2. THE OBJECT (The Instance)
            // ==========================================================
            // We use the 'new' keyword to allocate memory and create a real 
            // object based on the 'Laptop' blueprint.
            Laptop myWorkLaptop = new Laptop();

            // Assigning specific values to this specific object's properties
            myWorkLaptop.Brand = "Dell";
            myWorkLaptop.Model = "XPS 15";
            myWorkLaptop.RamGB = 16;

            // Creating a SECOND, completely independent object from the exact same blueprint
            Laptop myGamingLaptop = new Laptop();
            myGamingLaptop.Brand = "ASUS";
            myGamingLaptop.Model = "ROG Strix";
            myGamingLaptop.RamGB = 32;

            // Using the methods of our objects
            Console.WriteLine("Interacting with Object 1 (Work Laptop):");
            myWorkLaptop.DisplaySpecs();
            myWorkLaptop.PowerOn();

            Console.WriteLine("\nInteracting with Object 2 (Gaming Laptop):");
            myGamingLaptop.DisplaySpecs();
            myGamingLaptop.PowerOn();

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}