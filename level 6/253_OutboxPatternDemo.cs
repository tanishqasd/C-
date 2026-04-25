using System;

namespace AdvancedCSharp
{
    // 253. Outbox Pattern Implementation
    // Problem: You save a user to the DB, but crash before sending the "UserCreated" message to RabbitMQ.
    // Solution: Save the user AND the message to the DB in the SAME transaction (The Outbox).
    // A background worker later reads the Outbox and safely sends the messages to RabbitMQ.

    public class DatabaseTransaction
    {
        public void SaveWorkerAndQueueMessage(string workerName)
        {
            Console.WriteLine("--- Outbox Pattern ---");
            Console.WriteLine("BEGIN SQL TRANSACTION");
            
            try
            {
                Console.WriteLine($"INSERT INTO Workers (Name) VALUES ('{workerName}')");
                
                // Instead of sending to RabbitMQ directly, we write it to an Outbox table
                Console.WriteLine($"INSERT INTO OutboxMessages (Event, Payload) VALUES ('WorkerAdded', '{workerName}')");
                
                Console.WriteLine("COMMIT SQL TRANSACTION");
                Console.WriteLine("-> Both records saved safely. A background worker will dispatch the Outbox message later.");
            }
            catch
            {
                Console.WriteLine("ROLLBACK SQL TRANSACTION");
            }
        }
    }

    class Program
    {
        static void Main() => new DatabaseTransaction().SaveWorkerAndQueueMessage("Alice Foreman");
    }
}