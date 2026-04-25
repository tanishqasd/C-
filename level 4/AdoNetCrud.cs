using System;
using System.Data.SqlClient;

class Program
{
    // Note: Requires System.Data.SqlClient NuGet package
    static string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

    static void Main()
    {
        Console.WriteLine("--- ADO.NET CRUD Demo ---");
        // In a real scenario, you would wrap this in a try-catch block
        
        // 1. CREATE
        InsertRecord("Tanishqa", "MBA");
        
        // 2. READ
        ReadRecords();
    }

    static void InsertRecord(string name, string course)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Students (Name, Course) VALUES (@Name, @Course)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Course", course);

                connection.Open();
                int result = command.ExecuteNonQuery();
                Console.WriteLine(result > 0 ? "Record Inserted Successfully." : "Insert Failed.");
            }
        }
    }

    static void ReadRecords()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Course FROM Students";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Course: {reader["Course"]}");
                    }
                }
            }
        }
    }
}