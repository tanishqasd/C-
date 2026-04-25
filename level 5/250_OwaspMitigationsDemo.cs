using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System;

namespace AdvancedCSharp
{
    // 250. OWASP Top 10 Mitigations in C#
    // The Open Worldwide Application Security Project defines the top security flaws.
    // This file demonstrates mitigating Injection (SQLi) and Cross-Site Scripting (XSS).

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- OWASP Top 10 Mitigations ---");

            string maliciousUserInput = "'; DROP TABLE Workers; --"; // Classic SQL Injection attack
            string maliciousHtmlInput = "<script>alert('Stealing cookies!');</script>"; // Classic XSS attack

            // 1. MITIGATING SQL INJECTION (SQLi)
            // NEVER concatenate strings into SQL commands! Always use Parameters.
            Console.WriteLine("\n[1. Preventing SQL Injection]");
            string safeQuery = "SELECT * FROM Workers WHERE Name = @WorkerName";
            using var command = new SqlCommand(safeQuery);
            // The database engine treats @WorkerName strictly as literal text, completely neutralizing the attack
            command.Parameters.AddWithValue("@WorkerName", maliciousUserInput); 
            Console.WriteLine("Command parameterized securely.");

            // 2. MITIGATING CROSS-SITE SCRIPTING (XSS)
            // If you accept text from a user and display it back on a webpage, you must encode it.
            Console.WriteLine("\n[2. Preventing XSS]");
            string safeHtmlOutput = HtmlEncoder.Default.Encode(maliciousHtmlInput);
            Console.WriteLine($"Original HTML: {maliciousHtmlInput}");
            Console.WriteLine($"Encoded Safe HTML: {safeHtmlOutput}");
            Console.WriteLine("(The browser will render this as harmless text, not executable code.)");
        }
    }
}