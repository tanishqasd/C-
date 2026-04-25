using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AdvancedCSharp
{
    // 228. SQL Bulk Copy via C#
    // If you need to upload 50,000 material audit records from an Excel sheet, 
    // doing it one-by-one via Entity Framework will take minutes. 
    // SqlBulkCopy does it in milliseconds by bypassing normal SQL processing.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- SQL Bulk Copy ---");

            // 1. Create an in-memory data table matching the SQL schema
            DataTable table = new DataTable("MaterialAudits");
            table.Columns.Add("AuditId", typeof(int));
            table.Columns.Add("Material", typeof(string));
            table.Columns.Add("Quantity", typeof(int));

            // 2. Populate with 10,000 rows rapidly
            for (int i = 0; i < 10000; i++)
            {
                table.Rows.Add(i, "Cement", 50);
            }

            string connectionString = "Server=localhost;Database=Db;Trusted_Connection=True;";

            // 3. Stream the entire table directly into the SQL database
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = "MaterialAudits";
                        // bulkCopy.WriteToServer(table);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Expected for Demo]: {ex.Message}");
            }

            Console.WriteLine("Successfully buffered 10,000 records for bulk insertion.");
        }
    }
}