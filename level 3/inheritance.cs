using System;

namespace InheritanceDemo
{
    // 1. THE BASE CLASS (Parent)
    // This class contains common attributes and behaviors that multiple things might share.
    class Vehicle
    {
        public string Brand { get; set; }
        public int Year { get; set; }

        // Base class constructor
        public Vehicle(string brand, int year)
        {
            Brand = brand;
            Year = year;
        }

        // Common method for all vehicles
        public void StartEngine()
        {
            Console.WriteLine($"The {Year} {Brand}'s engine is starting... Vroom!");
        }

        // Common method for all vehicles
        public void StopEngine()
        {
            Console.WriteLine($"The {Brand}'s engine is turning off.");
        }
    }

    // 2. THE DERIVED CLASS (Child)
    // The colon (:) indicates that 'Car' inherits from 'Vehicle'
    class Car : Vehicle
    {
        // Unique property that belongs specifically to a Car, not all Vehicles
        public int NumberOfDoors { get; set; }

        // Child class constructor
        // The 'base' keyword passes the brand and year parameters up to the Parent's constructor
        public Car(string brand, int year, int numberOfDoors) : base(brand, year)
        {
            NumberOfDoors = numberOfDoors;
        }

        // Unique method that belongs specifically to a Car
        public void Honk()
        {
            Console.WriteLine("Beep beep!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Inheritance Demo ---\n");

            // We instantiate the Child class (Car)
            Car myCar = new Car("Toyota", 2024, 4);

            // Accessing inherited properties (Brand, Year) alongside unique properties (NumberOfDoors)
            Console.WriteLine($"Vehicle Details: {myCar.Year} {myCar.Brand} with {myCar.NumberOfDoors} doors.");

            // Accessing an inherited method
            myCar.StartEngine();

            // Accessing a method unique to the Child class
            myCar.Honk();

            // Accessing another inherited method
            myCar.StopEngine();

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}