using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus; // Requires Azure.Messaging.ServiceBus NuGet

namespace AdvancedCSharp
{
    // 257. Azure Service Bus Queues
    // Azure Service Bus is the enterprise-grade, cloud-hosted alternative to RabbitMQ.
    // It is used for high-value financial or operational messages where guaranteed delivery is critical.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- Azure Service Bus ---");

            string connectionString = "Endpoint=sb://my-service-bus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=myKey";
            string queueName = "payroll-processing-queue";

            try
            {
                await using var client = new ServiceBusClient(connectionString);
                ServiceBusSender sender = client.CreateSender(queueName);

                // Create a batch
                using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

                // Add messages to the batch
                messageBatch.TryAddMessage(new ServiceBusMessage("Process payroll for Worker ID: W-1042"));
                messageBatch.TryAddMessage(new ServiceBusMessage("Process payroll for Worker ID: W-1043"));

                Console.WriteLine("Sending payroll batch to Azure cloud queue...");
                
                // await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine("Batch dispatched successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Expected for Demo - Requires Azure setup]: {ex.Message}");
            }
        }
    }
}