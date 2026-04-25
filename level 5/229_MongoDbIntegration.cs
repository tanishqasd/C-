using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AdvancedCSharp
{
    // 229. MongoDB Integration (NoSQL)
    // Relational databases (SQL) require strict columns. NoSQL databases like MongoDB 
    // store unstructured JSON documents. This is perfect for things like "Site Incident Reports" 
    // where one report might have photos attached, and another might just be a text note.

    public class IncidentReport
    {
        public ObjectId Id { get; set; } // Mongo's native ID type
        public string Site { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
    }

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- MongoDB Integration ---");

            string connectionString = "mongodb://localhost:27017";
            
            try 
            {
                // 1. Connect to the MongoDB Server
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConstructionLogs");
                var collection = database.GetCollection<IncidentReport>("Incidents");

                // 2. Create a flexible document
                var report = new IncidentReport
                {
                    Site = "Sector 4",
                    Description = "Crane delay due to heavy rain.",
                    Tags = new[] { "Weather", "Delay", "Machinery" }
                };

                // 3. Insert into NoSQL
                // await collection.InsertOneAsync(report);
                Console.WriteLine("Incident Report structured for NoSQL insertion.");
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"[Demo Error]: {ex.Message}");
            }
        }
    }
}