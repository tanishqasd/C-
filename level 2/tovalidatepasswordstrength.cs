using System;
using System.Text.RegularExpressions;

class PasswordValidator
{
    public static void Main()
    {
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        
        string strength = ValidatePasswordStrength(password);
        Console.WriteLine($"Password Strength: {strength}");
    }
    
    public static string ValidatePasswordStrength(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8)
            return "Weak";
        
        bool hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
        bool hasLowerCase = Regex.IsMatch(password, @"[a-z]");
        bool hasDigit = Regex.IsMatch(password, @"[0-9]");
        bool hasSpecialChar = Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':"",.<>?/\\|`~]");
        
        int strength = 0;
        if (hasUpperCase) strength++;
        if (hasLowerCase) strength++;
        if (hasDigit) strength++;
        if (hasSpecialChar) strength++;
        
        return strength switch
        {
            0 or 1 => "Weak",
            2 => "Medium",
            3 => "Strong",
            _ => "Very Strong"
        };
    }
}