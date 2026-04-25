using System;

namespace ExceptionHandlingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Exception Handling Demo ---\n");

            // 1. The TRY block contains the "risky" code that might fail.
            try
            {
                int numerator = 10;
                int denominator = 0; // Setting this to 0 to force an error

                Console.WriteLine($"Attempting to divide {numerator} by {denominator}...");
                
                // This line will trigger a DivideByZeroException
                int result = numerator / denominator; 

                // If an exception occurs above, the runtime immediately jumps out of the try block.
                // Therefore, this next line will NEVER execute in this scenario.
                Console.WriteLine($"Success! The result is: {result}");
            }
            // 2. Specific CATCH blocks handle specific known errors.
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("[CAUGHT SPECIFIC ERROR] You cannot divide a number by zero!");
                Console.WriteLine($"System Details: {ex.Message}");
            }
            // 3. A general CATCH block handles anything else you didn't anticipate.
            // (Note: Specific catch blocks must always be written before generic ones).
            catch (Exception ex)
            {
                Console.WriteLine("[CAUGHT GENERAL ERROR] Something unexpected went wrong.");
                Console.WriteLine($"System Details: {ex.Message}");
            }
            // 4. The FINALLY block executes no matter what happens (success or failure).
            finally
            {
                Console.WriteLine("\n[FINALLY BLOCK] This runs unconditionally. Great for closing files or database connections.");
            }

            // Because we handled the exception, the program doesn't crash and continues running normally here.
            Console.WriteLine("\n--- Program Finished Successfully ---");
        }
    }
}