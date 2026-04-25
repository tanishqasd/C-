using System;
using System.Security.Cryptography;

// Never store passwords as plain text! Always hash them with a salt.
// This example uses PBKDF2, which is the standard algorithm used by ASP.NET Core Identity.
class PasswordManager
{
    private const int SaltSize = 16; // 128 bit 
    private const int KeySize = 32;  // 256 bit
    private const int Iterations = 100000;

    public static string HashPassword(string password)
    {
        using (var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256))
        {
            byte[] salt = algorithm.Salt;
            byte[] key = algorithm.GetBytes(KeySize);
            
            // Combine salt and key to store in the database
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(key);
        }
    }

    public static bool VerifyPassword(string hashToVerify, string password)
    {
        string[] parts = hashToVerify.Split(':');
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] storedKey = Convert.FromBase64String(parts[1]);

        using (var algorithm = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            byte[] keyToCheck = algorithm.GetBytes(KeySize);
            return CryptographicOperations.FixedTimeEquals(keyToCheck, storedKey);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Secure Password Hashing ---");
        
        string myPassword = "SuperSecurePassword123!";
        string hashedPassword = PasswordManager.HashPassword(myPassword);
        
        Console.WriteLine($"Original: {myPassword}");
        Console.WriteLine($"Hashed for Database: {hashedPassword}\n");

        Console.WriteLine($"Verify Correct Password: {PasswordManager.VerifyPassword(hashedPassword, myPassword)}");
        Console.WriteLine($"Verify Wrong Password: {PasswordManager.VerifyPassword(hashedPassword, "WrongPassword!")}");
    }
}