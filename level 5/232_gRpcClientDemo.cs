using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace AdvancedCSharp
{
    // 232. gRPC Client Consumption
    // This is how a completely separate C# application (like a desktop app on the site manager's laptop) 
    // securely and rapidly connects to the gRPC server we built above.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- gRPC Client Demo ---");

            // The URL of our running gRPC server
            string serverAddress = "https://localhost:5001";

            try
            {
                // 1. Establish the high-speed channel
                using var channel = GrpcChannel.ForAddress(serverAddress);
                
                // 2. Create the strongly-typed client
                // (EquipmentProvider.EquipmentProviderClient is auto-generated in a real setup)
                // var client = new EquipmentProvider.EquipmentProviderClient(channel);

                Console.WriteLine("Pinging Heavy Machinery Database via gRPC...");

                // 3. Make the call (Simulated for this demo)
                // var reply = await client.GetStatusAsync(new EquipmentStatusRequest { EquipmentId = "EXC-992" });
                
                // Console.WriteLine($"Machinery: {reply.EquipmentId}");
                // Console.WriteLine($"Operational: {reply.IsOperational}");
                // Console.WriteLine($"Fuel Level: {reply.CurrentFuelLevel}%");
                
                Console.WriteLine("[Simulated] Received binary response in 2ms. Decoded to C# object instantly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Demo Setup Error]: {ex.Message}");
            }
        }
    }
}