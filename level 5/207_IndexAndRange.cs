using System;

namespace AdvancedCSharp
{
    // 207. Index and Range Operators (^ and ..)
    // These operators provide a highly readable way to slice arrays and collections.
    // ^1 means "1 from the end".
    // 1..4 means "from index 1 up to (but not including) index 4".

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Index and Range Operators ---");

            // A typical 7-day log of cement bags used on site
            int[] dailyCementUsage = { 100, 120, 110, 150, 130, 90, 80 };

            // 1. Index Operator (^)
            int lastDayUsage = dailyCementUsage[^1]; 
            int secondToLastDay = dailyCementUsage[^2];
            
            Console.WriteLine($"Usage on final day: {lastDayUsage}");
            Console.WriteLine($"Usage on second-to-last day: {secondToLastDay}\n");

            // 2. Range Operator (..)
            // Extracting the midweek usage (Tuesday to Thursday / Index 1 to 3)
            int[] midweekUsage = dailyCementUsage[1..4]; 
            
            Console.WriteLine("Midweek Usage (Tue-Thu):");
            foreach (var amount in midweekUsage)
            {
                Console.WriteLine($"- {amount} bags");
            }

            // Extracting everything from Thursday onward (Index 3 to end)
            int[] lateWeek = dailyCementUsage[3..];
        }
    }
}