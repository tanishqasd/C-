using System;
using System.Data.SqlClient;

class Program
{
    // A standard connection string pointing to a cloud database on Azure.
    // In production, NEVER hardcode this. It should come from Azure Key Vault or environment variables.
    static string azureSqlConnectionString = "Server=tcp:my-construction-server.database.windows.net,1433;Initial Catalog=SiteManagementDb;Persist Security Info=False;User ID=azureuser;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    static void Main()
    {
        Console.WriteLine("--- Connecting to Azure SQL ---");

        try
        {
            using (SqlConnection connection = new SqlConnection(azureSqlConnectionString))
            {
                connection.Open();
                Console.WriteLine("Successfully connected to the Azure SQL Cloud Database.");

                string query = "SELECT COUNT(*) FROM MaterialInventory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    Console.WriteLine($"Total material records in cloud database: {count}");
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Azure Connection Failed: {ex.Message}");
        }
    }
}