using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("--- Microservices Communication Demo ---");

        // 1. Setup Dependency Injection for HttpClientFactory
        // This is the enterprise standard for managing HTTP connections between microservices
        var serviceProvider = new ServiceCollection()
            .AddHttpClient("InventoryService", client =>
            {
                // Pre-configure the base address for the target microservice
                client.BaseAddress = new Uri("https://api.inventory.internal/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .BuildServiceProvider();

        // 2. Request a configured client from the factory
        var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        var client = httpClientFactory.CreateClient("InventoryService");

        try
        {
            Console.WriteLine("Pinging the Inventory Microservice...");
            
            // 3. Make the call (simulated URL will fail in this demo)
            var response = await client.GetAsync("api/stock/cement");
            
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfully communicated with Inventory Service.");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"[Expected Error in Demo]: Could not resolve microservice endpoint. ({ex.Message})");
        }
    }
}