using System;
using System.Text.RegularExpressions;

class EmailValidator
{
    static void Main()
    {
        Console.Write("Enter an email address: ");
        string email = Console.ReadLine();
        
        if (IsValidEmail(email))
        {
            Console.WriteLine("The email format is valid.");
        }
        else
        {
            Console.WriteLine("The email format is invalid.");
        }
    }
    
    static bool IsValidEmail(string email)
    {
        try
        {
            // Regular expression pattern for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        catch
        {
            return false;
        }
    }
}