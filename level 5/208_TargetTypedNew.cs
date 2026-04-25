using System;
using System.Collections.Generic;

namespace AdvancedCSharp
{
    // 208. Target-Typed 'new' Expressions
    // This cleans up your code by omitting the type name after 'new' 
    // when the compiler can easily figure it out from the variable declaration.

    public class MaterialOrder
    {
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Target-Typed new Expressions ---\n");

            // THE OLD WAY: Repetitive type naming
            MaterialOrder oldOrder = new MaterialOrder { MaterialName = "Steel", Quantity = 50 };
            
            // THE MODERN WAY: The compiler knows it must be a MaterialOrder
            MaterialOrder modernOrder = new() { MaterialName = "Steel", Quantity = 50 };

            // This is especially powerful for complex generic collections!
            // OLD: Dictionary<string, List<MaterialOrder>> inventory = new Dictionary<string, List<MaterialOrder>>();
            // NEW:
            Dictionary<string, List<MaterialOrder>> inventory = new();

            inventory.Add("Site A", new() 
            { 
                new() { MaterialName = "Cement", Quantity = 100 },
                new() { MaterialName = "Bricks", Quantity = 5000 }
            });

            Console.WriteLine($"Stored {inventory["Site A"].Count} material types for Site A using minimal syntax.");
        }
    }
}