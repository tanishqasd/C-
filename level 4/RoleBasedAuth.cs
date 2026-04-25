using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } // e.g., "Admin", "Standard"
}

class Program
{
    static List<User> users = new List<User>
    {
        new User { Username = "admin", Password = "123", Role = "Admin" },
        new User { Username = "tanishqa", Password = "abc", Role = "Standard" }
    };

    static User CurrentUser;

    static void Main()
    {
        Console.WriteLine("--- Secure Login ---");
        Console.Write("Username: ");
        string un = Console.ReadLine();
        Console.Write("Password: ");
        string pw = Console.ReadLine();

        CurrentUser = users.FirstOrDefault(u => u.Username == un && u.Password == pw);

        if (CurrentUser != null)
        {
            Console.WriteLine($"\nWelcome, {CurrentUser.Username}! Role: {CurrentUser.Role}");
            AccessAdminPanel();
        }
        else
        {
            Console.WriteLine("Authentication failed. Invalid credentials.");
        }
    }

    static void AccessAdminPanel()
    {
        // Authorization Check
        if (CurrentUser.Role == "Admin")
        {
            Console.WriteLine("[SUCCESS] Access granted to restricted Admin Dashboard.");
        }
        else
        {
            Console.WriteLine("[DENIED] You do not have permission to view this panel. Admins only.");
        }
    }
}