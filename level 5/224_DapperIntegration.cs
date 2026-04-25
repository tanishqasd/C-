using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper; // Requires Dapper NuGet Package

namespace AdvancedCSharp
{
    // 224. Dapper Micro-ORM Integration
    // Entity Framework is great for saving data, but for reading massive reports, it can be slow.
    // Dapper is a "Micro-ORM" used by StackOverflow. It maps raw SQL directly to C# objects 
    // at lightning speed.

    public class SiteReport
    {
        public string SiteName { get; set; }
        public decimal TotalCost { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Dapper Micro-ORM ---");
            
            string connectionString = "Server=myServer;Database=ConstructionDb;Trusted_Connection=True;";
            
            // Note: Wrapped in a try/catch because the dummy connection string will fail locally
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Writing high-performance, raw SQL
                    string sql = @"
                        SELECT s.Name as SiteName, SUM(m.Cost) as TotalCost
                        FROM Sites s
                        INNER JOIN MaterialLogs m ON s.Id = m.SiteId
                        WHERE s.IsActive = 1
                        GROUP BY s.Name";

                    // Dapper magically executes the SQL and maps the columns to the SiteReport properties
                    var reports = connection.Query<SiteReport>(sql).ToList();

                    foreach (var report in reports)
                    {
                        Console.WriteLine($"Site: {report.SiteName} | Cost: ${report.TotalCost}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Expected error for demo connection]: {ex.Message}");
            }
        }
    }
}
