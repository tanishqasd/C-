using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 233. GraphQL API (using HotChocolate)
    // Unlike REST, where the server decides what data is returned, GraphQL lets the CLIENT 
    // (like your React frontend) ask for exactly the fields it wants. This prevents 
    // over-fetching (downloading data you don't need) and under-fetching.

    public class Worker
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public decimal HourlyRate { get; set; }
    }

    // This is the "Query" class that exposes our data
    public class Query
    {
        public IQueryable<Worker> GetWorkers() => new List<Worker>
        {
            new() { Id = "W1", Name = "Tanishqa", Role = "Site Manager", HourlyRate = 45.00m },
            new() { Id = "W2", Name = "Rahul", Role = "Foreman", HourlyRate = 30.00m }
        }.AsQueryable();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- GraphQL API Setup ---");
            
            var builder = WebApplication.CreateBuilder(args);

            // Register HotChocolate GraphQL server
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>();

            var app = builder.Build();

            // Enable the GraphQL endpoint (usually at /graphql)
            app.MapGraphQL();

            Console.WriteLine("GraphQL Endpoint Configured. React clients can now query precise data trees.");
            // app.Run();
        }
    }
}