using System;
using System.Text;
using RabbitMQ.Client; // Requires RabbitMQ.Client NuGet package

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Message Queue Demo (RabbitMQ) ---");

        // 1. Establish connection to the local RabbitMQ server
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            // 2. Declare a queue to ensure it exists
            channel.QueueDeclare(queue: "material_orders",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = "Order #1042: 500 bags of cement required at Site A.";
            var body = Encoding.UTF8.GetBytes(message);

            // 3. Publish the message to the queue
            channel.BasicPublish(exchange: "",
                                 routingKey: "material_orders",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine($"[x] Sent: {message}");
        }
        
        // Note: A separate "Consumer" application would read from this queue.
    }
}