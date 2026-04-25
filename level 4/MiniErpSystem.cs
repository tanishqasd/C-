using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Enterprise Resource Planning (ERP) System ===");
            Console.WriteLine("1. Human Resources (HR) Module");
            Console.WriteLine("2. Finance & Accounting Module");
            Console.WriteLine("3. Supply Chain Module");
            Console.WriteLine("4. Exit System");
            Console.Write("Select Module: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("[HR] Loading payroll and employee directories...");
                    break;
                case "2":
                    Console.WriteLine("[Finance] Loading quarterly ledgers and accounts payable...");
                    break;
                case "3":
                    Console.WriteLine("[Supply Chain] Loading inventory routing and vendor manifests...");
                    break;
                case "4":
                    Console.WriteLine("Safely shutting down ERP...");
                    return;
                default:
                    Console.WriteLine("Invalid command. Please select a valid module.");
                    break;
            }
        }
    }
}