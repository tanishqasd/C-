using System;
using System.Collections.Generic;

namespace AdvancedCSharp
{
    // 205. Custom Iterators using 'yield return'.
    // This allows you to generate sequences of data on the fly. It is highly efficient 
    // for implementing pagination logic before sending data to a frontend table.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Custom Iterators (Yield Return) ---");

            Console.WriteLine("Generating inspection schedule:");
            foreach (var date in GetUpcomingInspections(3))
            {
                Console.WriteLine($"Scheduled Inspection: {date:yyyy-MM-dd}");
            }
        }

        static IEnumerable<DateTime> GetUpcomingInspections(int count)
        {
            DateTime currentDate = DateTime.Now;
            int generated = 0;

            while (generated < count)
            {
                currentDate = currentDate.AddDays(1);
                
                // Skip weekends for inspections
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    generated++;
                    // 'yield return' pauses the method, returns the value, and resumes here on the next iteration
                    yield return currentDate; 
                }
            }
        }
    }
}