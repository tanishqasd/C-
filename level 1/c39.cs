using System;

class SalaryCalculator
{
    static void Main()
    {
        Console.WriteLine("=== Salary Calculator with Allowances ===\n");
        
        // Input basic salary
        Console.Write("Enter basic salary: ");
        double basicSalary = double.Parse(Console.ReadLine());
        
        // Input allowances
        Console.Write("Enter house rent allowance (HRA %): ");
        double hraPercentage = double.Parse(Console.ReadLine());
        
        Console.Write("Enter dearness allowance (DA %): ");
        double daPercentage = double.Parse(Console.ReadLine());
        
        Console.Write("Enter other allowances: ");
        double otherAllowances = double.Parse(Console.ReadLine());
        
        // Calculate allowances
        double hra = (basicSalary * hraPercentage) / 100;
        double da = (basicSalary * daPercentage) / 100;
        
        // Calculate total salary
        double totalSalary = basicSalary + hra + da + otherAllowances;
        
        // Display results
        Console.WriteLine("\n=== Salary Breakdown ===");
        Console.WriteLine($"Basic Salary: Rs. {basicSalary:F2}");
        Console.WriteLine($"HRA: Rs. {hra:F2}");
        Console.WriteLine($"DA: Rs. {da:F2}");
        Console.WriteLine($"Other Allowances: Rs. {otherAllowances:F2}");
        Console.WriteLine($"----------------------------");
        Console.WriteLine($"Total Salary: Rs. {totalSalary:F2}");
    }
}