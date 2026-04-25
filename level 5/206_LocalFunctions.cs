using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharp
{
    // 206. Local Functions vs Lambdas.
    // Local functions are methods nested inside other methods. Unlike lambdas, 
    // they can be recursive, use 'yield return', and are slightly faster because 
    // they don't allocate memory for a delegate.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Local Functions Demo ---");
            ProcessWeeklyPayroll(new[] { 40, 45, 38, 50 });
        }

        static void ProcessWeeklyPayroll(int[] hoursWorked)
        {
            decimal baseRate = 20.00m;

            // This is a Local Function. It lives entirely inside ProcessWeeklyPayroll.
            // It has direct access to 'baseRate' without needing it passed as a parameter.
            decimal CalculateWorkerPay(int hours)
            {
                if (hours <= 40) return hours * baseRate;
                
                int overtime = hours - 40;
                return (40 * baseRate) + (overtime * baseRate * 1.5m);
            }

            for (int i = 0; i < hoursWorked.Length; i++)
            {
                decimal pay = CalculateWorkerPay(hoursWorked[i]);
                Console.WriteLine($"Worker {i + 1} (Hours: {hoursWorked[i]}): ${pay}");
            }
        }
    }
}