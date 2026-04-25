using System;
using System.Security.Cryptography;
using System.Text;

namespace AdvancedCSharp
{
    // 242. RSA Asymmetric Encryption
    // Asymmetric encryption uses a PUBLIC key to encrypt, and a PRIVATE key to decrypt.
    // This is used when a vendor needs to send you a secure contract over the internet. 
    // They encrypt it with your Public Key, and ONLY your Private Key can open it.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- RSA Asymmetric Encryption ---");

            string vendorContractData = "CONFIDENTIAL: Steel Supply Agreement - $500,000";

            // Create a new RSA instance (generates public/private key pair automatically)
            using RSA rsa = RSA.Create();
            
            // Export the public key (You would share this with the vendor)
            string publicKey = rsa.ToXmlString(false);

            // 1. VENDOR ENCRYPTS DATA (using your Public Key)
            using RSA vendorRsa = RSA.Create();
            vendorRsa.FromXmlString(publicKey);
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(vendorContractData);
            byte[] encryptedData = vendorRsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);
            
            Console.WriteLine($"Encrypted Contract: {Convert.ToBase64String(encryptedData).Substring(0, 30)}...\n");

            // 2. YOU DECRYPT DATA (using your Private Key held in the original 'rsa' object)
            byte[] decryptedBytes = rsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);
            string decryptedContract = Encoding.UTF8.GetString(decryptedBytes);

            Console.WriteLine($"Decrypted Contract: {decryptedContract}");
        }
    }
}