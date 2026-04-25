using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    // 218. Channels for Producer/Consumer
    // System.Threading.Channels is the modern, thread-safe way to handle scenarios where 
    // one part of your app produces data (e.g., 500 workers swiping their ID cards) 
    // and another part consumes it (e.g., the database saving those logs) without locking or crashing.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- Channels (Producer / Consumer) ---");

            // Create an unbounded channel (can hold infinite items)
            var channel = Channel.CreateUnbounded<string>();

            // Start the consumer in the background
            var consumerTask = ConsumeWorkerLogsAsync(channel.Reader);

            // Produce data: Simulate workers swiping into the site
            for (int i = 1; i <= 5; i++)
            {
                string log = $"Worker_{i} swiped in at {DateTime.Now:HH:mm:ss}";
                await channel.Writer.WriteAsync(log);
                Console.WriteLine($"[Producer] Sent: {log}");
                await Task.Delay(200); // Wait a bit between swipes
            }

            // Tell the channel we are done sending data
            channel.Writer.Complete();

            // Wait for the consumer to finish processing everything
            await consumerTask;
            Console.WriteLine("All logs processed securely.");
        }

        static async Task ConsumeWorkerLogsAsync(ChannelReader<string> reader)
        {
            // WaitToReadAsync pauses until data is available, avoiding CPU waste
            while (await reader.WaitToReadAsync())
            {
                while (reader.TryRead(out var log))
                {
                    await Task.Delay(500); // Simulate heavy database write
                    Console.WriteLine($"   -> [Consumer] Saved to Database: {log}");
                }
            }
        }
    }
}