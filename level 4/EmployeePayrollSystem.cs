using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; }
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public decimal CalculatePay()
    {
        decimal basePay = HourlyRate * HoursWorked;
        // Apply overtime logic (1.5x pay for hours over 40)
        if (HoursWorked > 40)
        {
            int overtimeHours = HoursWorked - 40;
            basePay += (overtimeHours * HourlyRate * 0.5m); 
        }
        return basePay;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> payroll = new List<Employee>
        {
            new Employee { Name = "Alice", HourlyRate = 25m, HoursWorked = 40 },
            new Employee { Name = "Bob", HourlyRate = 20m, HoursWorked = 50 } // Has overtime
        };

        Console.WriteLine("--- Payroll Report ---");
        foreach (var emp in payroll)
        {
            Console.WriteLine($"{emp.Name}: ${emp.CalculatePay()}");
        }
    }
}