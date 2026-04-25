using System;

namespace Level5_DDD
{
    // 268. Factory Pattern for Complex Entities.
    // When creating an object requires complex logic or validation, 
    // you use a Factory instead of a simple constructor.

    public class SiteMachine
    {
        public string Type { get; internal set; }
        public string LicenseRequired { get; internal set; }
    }

    public static class MachineFactory
    {
        public static SiteMachine Create(string type)
        {
            return type.ToLower() switch
            {
                "crane" => new SiteMachine { Type = "Crane", LicenseRequired = "Heavy-Class A" },
                "excavator" => new SiteMachine { Type = "Excavator", LicenseRequired = "Class B" },
                _ => throw new ArgumentException("Unknown machine type")
            };
        }
    }

    class Program
    {
        static void Main()
        {
            var crane = MachineFactory.Create("crane");
            Console.WriteLine($"Factory created {crane.Type} requiring {crane.LicenseRequired} license.");
        }
    }
}