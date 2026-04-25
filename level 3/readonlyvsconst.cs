using System;
using System.Threading;

namespace ConstantsDemo
{
    class ServerConfiguration
    {
        // ==========================================================
        // 1. CONST (Compile-Time Constant)
        // ==========================================================
        // Must be initialized right here at the time of declaration.
        // It is implicitly static (belongs to the class, not the instance).
        public const string ApplicationName = "Enterprise ERP Node";
        public const int MaxConnections = 1000;

        // ==========================================================
        // 2. READONLY (Run-Time Constant)
        // ==========================================================
        // Can be left uninitialized here.
        // It belongs to the specific instance of the object.
        public readonly DateTime BootTime;
        public readonly string ServerId;

        // Constructor
        public ServerConfiguration(string serverId)
        {
            // We assign the readonly values at runtime. 
            // This is impossible to do with a 'const' field.
            ServerId = serverId;
            BootTime = DateTime.Now;

            // ERROR: If you uncomment the line below, it will not compile.
            // You cannot modify a const inside a constructor or anywhere else.
            // MaxConnections = 2000; 
        }

        public void AttemptModifications()
        {
            // ERROR: None of these will compile if uncommented.
            // Both const and readonly are locked after initialization.
            // ApplicationName = "New Name"; 
            // ServerId = "Server-002";      
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Const vs Readonly Demo ---\n");

            // CONST fields are accessed via the Class Name itself, NOT an object instance.
            Console.WriteLine($"[CONST] Starting Application: {ServerConfiguration.ApplicationName}");
            Console.WriteLine($"[CONST] Maximum Connections Allowed: {ServerConfiguration.MaxConnections}\n");

            // Instantiating the first server configuration
            ServerConfiguration server1 = new ServerConfiguration("Node-Alpha-01");
            Console.WriteLine($"[READONLY] Server 1 ID: {server1.ServerId}");
            Console.WriteLine($"[READONLY] Server 1 Boot Time: {server1.BootTime}");

            // Pausing for 2 seconds to prove runtime assignment
            Console.WriteLine("\nWaiting 2 seconds to boot second server...\n");
            Thread.Sleep(2000); 

            // Instantiating the second server configuration
            // Notice how the readonly 'BootTime' field captures a totally different value!
            ServerConfiguration server2 = new ServerConfiguration("Node-Beta-02");
            Console.WriteLine($"[READONLY] Server 2 ID: {server2.ServerId}");
            Console.WriteLine($"[READONLY] Server 2 Boot Time: {server2.BootTime}");

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}