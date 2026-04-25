using System;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    // 219. ThreadPool Starvation Prevention
    // One of the biggest causes of production server crashes is "sync-over-async" code.
    // Calling .Result or .Wait() on a Task blocks a thread completely, eventually 
    // running the server out of available threads (Starvation).

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- ThreadPool Starvation Prevention ---");
            
            Console.WriteLine("Executing safe, fully asynchronous chain...");
            
            // THE GOOD WAY: Async all the way down. The thread is freed while waiting.
            string blueprint = await DownloadBlueprintAsync();
            Console.WriteLine($"Success: {blueprint}");

            // THE BAD WAY (Do not do this in an ASP.NET API!):
            // string badBlueprint = DownloadBlueprintAsync().Result; 
        }

        static async Task<string> DownloadBlueprintAsync()
        {
            // Simulate a massive 5-second file download from Azure Blob Storage
            await Task.Delay(2000); 
            
            return "Foundation_Blueprint_V3.pdf downloaded securely.";
        }
    }
}