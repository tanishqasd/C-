using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    // 217. ValueTask vs Task
    // A standard 'Task' allocates memory on the Heap every single time it is called.
    // 'ValueTask' avoids this allocation if the result is already available synchronously 
    // (e.g., if the data is already cached). 

    class Program
    {
        // Simulating a fast, in-memory cache for site managers
        static Dictionary<int, string> _managerCache = new() { { 1, "Tanishqa" } };

        static async Task Main()
        {
            Console.WriteLine("--- ValueTask Optimization ---");

            // First call: Returns instantly from cache (Zero allocation!)
            string manager1 = await GetSiteManagerAsync(1);
            Console.WriteLine($"Found: {manager1}");

            // Second call: Simulates a database trip
            string manager2 = await GetSiteManagerAsync(2);
            Console.WriteLine($"Found: {manager2}");
        }

        static ValueTask<string> GetSiteManagerAsync(int id)
        {
            if (_managerCache.TryGetValue(id, out string name))
            {
                Console.WriteLine("[ValueTask] Returned synchronously from cache.");
                return new ValueTask<string>(name); 
            }

            Console.WriteLine("[ValueTask] Cache miss. Falling back to async DB call.");
            return new ValueTask<string>(FetchFromDatabaseAsync(id));
        }

        static async Task<string> FetchFromDatabaseAsync(int id)
        {
            await Task.Delay(1000); // Simulate network latency
            return "New Manager Assigned";
        }
    }
}