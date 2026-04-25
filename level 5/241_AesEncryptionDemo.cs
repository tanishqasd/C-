using System;
using System.IO;
using System.Security.Cryptography;

namespace AdvancedCSharp
{
    // 241. AES Symmetric Encryption
    // Symmetric encryption uses the SAME key to encrypt and decrypt data.
    // AES (Advanced Encryption Standard) is military-grade and perfect for storing 
    // highly sensitive data like Worker Bank Account Numbers in your database.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- AES Symmetric Encryption ---");

            string sensitiveData = "Worker Bank Account: 1234-5678-9012";
            
            // Generate a secure, random key and IV (Initialization Vector)
            using Aes aesAlg = Aes.Create();
            byte[] key = aesAlg.Key;
            byte[] iv = aesAlg.IV;

            // Encrypt
            byte[] encryptedData = EncryptStringToBytes_Aes(sensitiveData, key, iv);
            Console.WriteLine($"Encrypted (Base64): {Convert.ToBase64String(encryptedData)}");

            // Decrypt
            string decryptedData = DecryptStringFromBytes_Aes(encryptedData, key, iv);
            Console.WriteLine($"Decrypted: {decryptedData}");
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            using ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt);
            
            swEncrypt.Write(plainText);
            swEncrypt.Close(); // Must close to flush the final block
            return msEncrypt.ToArray();
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            using ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msDecrypt = new(cipherText);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            
            return srDecrypt.ReadToEnd();
        }
    }
}