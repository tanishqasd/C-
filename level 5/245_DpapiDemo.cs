using System;
using System.Security.Cryptography;
using System.Text;

namespace AdvancedCSharp
{
    // 245. Data Protection API (DPAPI)
    // DPAPI is built directly into Windows. It encrypts data using the current Windows User's login credentials.
    // This is perfect for a local WPF/Console app installed on the Site Manager's laptop 
    // so they can securely save their local database connection string without managing AES keys.
    // Note: Requires the System.Security.Cryptography.ProtectedData NuGet package.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Windows DPAPI ---");

            string localSecret = "Local_Db_Password=MySuperSecretPassword";
            byte[] secretBytes = Encoding.UTF8.GetBytes(localSecret);

            try
            {
                // Encrypt data tied specifically to the currently logged-in Windows User
                byte[] encryptedBytes = ProtectedData.Protect(secretBytes, null, DataProtectionScope.CurrentUser);
                Console.WriteLine("Data encrypted securely using Windows credentials.");

                // Decrypt data (will instantly fail if another Windows user tries to run this)
                byte[] decryptedBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
                Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decryptedBytes)}");
            }
            catch (PlatformNotSupportedException)
            {
                Console.WriteLine("DPAPI is a Windows-only feature and cannot run on Linux/Mac.");
            }
        }
    }
}