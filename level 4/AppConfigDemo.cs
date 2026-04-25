using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration; // Requires Microsoft.Extensions.Configuration.Json

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Configuration Management Demo ---");

        // Simulating the creation of an appsettings.json file in memory for the console
        var inMemorySettings = new Dictionary<string, string> {
            {"ConnectionStrings:DefaultConnection", "Server=ProductionDB; Database=AppDb;"},
            {"EmailSettings:SmtpServer", "smtp.office365.com"},
            {"EmailSettings:Port", "587"}
        };

        // Building the configuration object
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        // Retrieving values using standard .NET syntax
        string dbConnection = configuration.GetConnectionString("DefaultConnection");
        string smtpServer = configuration["EmailSettings:SmtpServer"];
        
        Console.WriteLine($"Database Configured to: {dbConnection}");
        Console.WriteLine($"Email Outbound Server: {smtpServer}");
    }
}