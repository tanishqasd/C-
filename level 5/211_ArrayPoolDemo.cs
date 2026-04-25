using System;
using System.Buffers;

namespace AdvancedCSharp
{
    // 211. ArrayPool for Memory Reuse
    // Creating massive arrays frequently forces the Garbage Collector to pause your application 
    // to clean up memory. ArrayPool lets you "rent" an array, use it, and return it, 
    // completely avoiding memory allocation overhead.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- ArrayPool Memory Reuse ---");
            
            // Scenario: Processing a massive batch of sensor readings from a site crane
            int dataSize = 100_000;

            // 1. RENT the array instead of using 'new int[100000]'
            // Note: The pool may return an array slightly larger than requested!
            int[] sensorDataBuffer = ArrayPool<int>.Shared.Rent(dataSize);

            try
            {
                Console.WriteLine($"Rented an array of size: {sensorDataBuffer.Length} (Requested: {dataSize})");

                // Simulate populating the data
                for (int i = 0; i < dataSize; i++)
                {
                    sensorDataBuffer[i] = i * 2; 
                }

                Console.WriteLine($"Processed data successfully. Last value: {sensorDataBuffer[dataSize - 1]}");
            }
            finally
            {
                // 2. RETURN the array to the pool so it can be reused elsewhere
                // The 'true' parameter clears the array data for security purposes before returning it
                ArrayPool<int>.Shared.Return(sensorDataBuffer, clearArray: true);
                Console.WriteLine("Buffer securely returned to the ArrayPool.");
            }
        }
    }
}