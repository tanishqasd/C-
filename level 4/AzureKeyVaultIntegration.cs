using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

// Azure Key Vault securely stores API keys, database passwords, and certificates 
// so you never have to hardcode them in your source code.
class Program
{
    static async Task Main()
    {
        Console.WriteLine("--- Azure Key Vault Demo ---");

        string keyVaultUrl = "https://your-unique-key-vault-name.vault.azure.net/";
        
        try
        {
            // DefaultAzureCredential automatically uses your local Azure CLI login during development, 
            // and the server's Managed Identity when deployed to the cloud.
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Retrieve a highly sensitive database password
            KeyVaultSecret secret = await client.GetSecretAsync("DatabasePassword");
            
            Console.WriteLine($"Successfully retrieved secret: {secret.Name}");
            // Console.WriteLine($"Value: {secret.Value}"); // Never actually print secrets in production logs!
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to Key Vault: {ex.Message}");
        }
    }
}