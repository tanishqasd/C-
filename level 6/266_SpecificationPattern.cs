using System;
using System.Collections.Generic;
using System.Linq;

namespace Level5_DDD
{
    // 266. Specification Pattern.
    // This encapsulates business rules into reusable objects. 
    // Perfect for checking: "Is this worker eligible for this high-risk task?"

    public class Worker 
    { 
        public string Name { get; set; } 
        public int YearsExperience { get; set; } 
        public bool HasSafetyCert { get; set; } 
    }

    public class HighRiskEligibilitySpecification
    {
        public bool IsSatisfiedBy(Worker worker) => 
            worker.YearsExperience >= 5 && worker.HasSafetyCert;
    }

    class Program
    {
        static void Main()
        {
            var worker = new Worker { Name = "Rahul", YearsExperience = 6, HasSafetyCert = true };
            var spec = new HighRiskEligibilitySpecification();

            Console.WriteLine($"Is {worker.Name} eligible for high-risk work? {spec.IsSatisfiedBy(worker)}");
        }
    }
}