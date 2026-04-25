using System;

namespace AdvancedCSharp
{
    // 209. Default Interface Methods
    // Historically, adding a new method to an interface broke every class that implemented it.
    // Now, you can provide a default implementation directly inside the interface to ensure backward compatibility.

    public interface IHeavyMachinery
    {
        string GetMachineId();
        void StartEngine();

        // New requirement added months later!
        // Because it has a default body, existing classes won't break.
        void LogMaintenance() 
        {
            Console.WriteLine($"[Default Log] Maintenance checked for machine: {GetMachineId()}");
        }
    }

    // This class was written BEFORE LogMaintenance was added to the interface.
    // It still compiles perfectly because the interface handles the missing method!
    public class Crane : IHeavyMachinery
    {
        public string GetMachineId() => "CRN-909";
        public void StartEngine() => Console.WriteLine("Crane engine started.");
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Default Interface Methods ---");

            IHeavyMachinery myCrane = new Crane();
            myCrane.StartEngine();
            
            // Calls the fallback method defined in the interface itself
            myCrane.LogMaintenance(); 
        }
    }
}