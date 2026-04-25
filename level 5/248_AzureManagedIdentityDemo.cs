using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Azure.Identity; // Requires Azure.Identity NuGet

namespace AdvancedCSharp
{
    // 248. Securing Connection Strings (Azure Managed Identities)
    // Storing database passwords in configuration files is a massive security risk. 
    // Azure Managed Identity allows your API to access the database using its own cloud identity—ZERO passwords required!

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- Azure Managed Identity (Passwordless DB) ---");

            // Notice there is NO Password in this connection string!
            string connectionString = "Server=tcp:my-construction-server.database.windows.net,1433;Database=SiteDb;";

            try
            {
                using var connection = new SqlConnection(connectionString);
                
                // Fetch an access token silently from Azure infrastructure
                var credential = new DefaultAzureCredential();
                var token = await credential.GetTokenAsync(new Azure.Core.TokenRequestContext(new[] { "https://database.windows.net/.default" }));
                
                // Attach the Azure token to the SQL connection
                connection.AccessToken = token.Token;

                await connection.OpenAsync();
                Console.WriteLine("Connected to Azure SQL Database without using a password!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Demo Setup Required]: Code requires Azure environment. ({ex.Message})");
            }
        }
    }
}