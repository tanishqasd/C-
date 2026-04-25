using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    // 203. IAsyncEnumerable allows you to stream data asynchronously. 
    // This is vital when querying massive datasets (like 10,000 material audit logs) 
    // so you don't crash the server's memory by loading them all at once.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- IAsyncEnumerable Data Streaming ---");
            Console.WriteLine("Fetching site audit logs in real-time...\n");

            // Consume the stream as it arrives
            await foreach (var log in FetchAuditLogsAsync())
            {
                Console.WriteLine(log);
            }
        }

        static async IAsyncEnumerable<string> FetchAuditLogsAsync()
        {
            for (int i = 1; i <= 5; i++)
            {
                // Simulate a database query delay for each chunk of records
                await Task.Delay(500); 
                yield return $"[Audit {i}] Material usage validated.";
            }
        }
    }
}