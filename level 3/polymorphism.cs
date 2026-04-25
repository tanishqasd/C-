using System;
using System.Collections.Generic;

namespace PolymorphismDemo
{
    // ==========================================================
    // 1. COMPILE-TIME POLYMORPHISM (Method Overloading)
    // ==========================================================
    class DocumentPrinter
    {
        // Form 1: Takes a single string
        public void Print(string text)
        {
            Console.WriteLine($"Printing Text: {text}");
        }

        // Form 2: Takes a string and an integer
        public void Print(string text, int copies)
        {
            Console.WriteLine($"Printing Text: {text} ({copies} copies)");
        }

        // Form 3: Takes an array of strings
        public void Print(string[] lines)
        {
            Console.WriteLine("Printing Multiple Lines:");
            foreach (var line in lines)
            {
                Console.WriteLine($" - {line}");
            }
        }
    }

    // ==========================================================
    // 2. RUN-TIME POLYMORPHISM (Method Overriding)
    // ==========================================================
    class Shape
    {
        // The 'virtual' keyword allows derived classes to change this behavior
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a generic shape.");
        }
    }

    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle: Calculating radius and rendering curve...");
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Rectangle: Calculating width and height and rendering lines...");
        }
    }

    // ==========================================================
    // MAIN EXECUTION
    // ==========================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Polymorphism Demo ---\n");

            // --- Demonstrating Compile-Time Polymorphism ---
            Console.WriteLine("--- 1. Method Overloading ---");
            DocumentPrinter printer = new DocumentPrinter();
            
            // The compiler knows exactly which 'Print' to use based on the arguments
            printer.Print("Project Proposal"); 
            printer.Print("Financial Report", 3);
            
            Console.WriteLine();

            // --- Demonstrating Run-Time Polymorphism ---
            Console.WriteLine("--- 2. Method Overriding ---");
            
            // The true power of polymorphism: We can store completely different 
            // objects inside a single collection of their base type.
            List<Shape> visualElements = new List<Shape>
            {
                new Shape(),
                new Circle(),
                new Rectangle()
            };

            // We can iterate through the list uniformly. 
            // The program figures out which specific 'Draw' method to execute dynamically.
            foreach (Shape element in visualElements)
            {
                element.Draw(); 
            }

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}