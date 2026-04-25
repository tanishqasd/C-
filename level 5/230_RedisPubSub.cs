using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace AdvancedCSharp
{
    // 230. Redis Pub/Sub Implementation
    // Redis is famous as a caching tool, but it also has a "Publish/Subscribe" engine.
    // One microservice "Publishes" a message, and ANY other microservice listening 
    // to that channel instantly reacts. It is incredibly fast.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- Redis Pub/Sub ---");

            try
            {
                // 1. Connect to the Redis Server
                var redis = ConnectionMultiplexer.Connect("localhost:6379");
                var subscriber = redis.GetSubscriber();

                // 2. Subscribe to a specific channel
                await subscriber.SubscribeAsync("site-emergencies", (channel, message) =>
                {
                    Console.WriteLine($"\n[ALERT RECEIVED] Channel: {channel} | Message: {message}");
                    Console.WriteLine("Initiating lockdown protocols...");
                });

                Console.WriteLine("Listening for emergencies... Press Enter to simulate publishing an alert.");
                Console.ReadLine();

                // 3. Publish to the channel (Usually done from a completely different application)
                await subscriber.PublishAsync("site-emergencies", "EVACUATE SECTOR 7 - GAS LEAK");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Demo Connection Failed]: Ensure Redis is running locally. ({ex.Message})");
            }
        }
    }
}