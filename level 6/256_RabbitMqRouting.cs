using System;
using System.Text;
using RabbitMQ.Client;

namespace AdvancedCSharp
{
    // 256. RabbitMQ Advanced Routing (Topic Exchange)
    // Instead of sending messages to one queue, you send them to an Exchange with a "Routing Key".
    // Queues subscribe to patterns. E.g., The Audit Queue listens to "site.*" while the 
    // Emergency Queue only listens to "site.emergency".

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- RabbitMQ Topic Routing ---");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            try
            {
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.ExchangeDeclare(exchange: "site_logs", type: ExchangeType.Topic);

                string routingKey = "site.weather.warning";
                string message = "High winds detected at Sector 4.";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "site_logs",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"[x] Sent '{routingKey}':'{message}'");
                Console.WriteLine("Any queue bound with 'site.weather.*' or 'site.#' received this message.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RabbitMQ connection failed]: {ex.Message}");
            }
        }
    }
}