using System;
using System.Security.Cryptography;
using System.Text;

namespace AdvancedCSharp
{
    // 243. HMAC Digital Signatures
    // HMAC (Hash-based Message Authentication Code) doesn't hide data; it proves nobody tampered with it.
    // If a Payment Gateway (like Stripe) sends a webhook saying "Invoice Paid", 
    // they attach an HMAC signature. You calculate the signature on your end to verify it matches.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- HMAC Digital Signatures ---");

            string sharedSecretKey = "SuperSecretWebhookKey123!";
            string payloadFromStripe = "{\"invoiceId\":\"INV-999\",\"status\":\"paid\"}";

            // 1. Generate the signature (What Stripe does before sending to you)
            string signature = GenerateHmacSignature(payloadFromStripe, sharedSecretKey);
            Console.WriteLine($"Signature attached to payload: {signature}\n");

            // 2. Verify the payload hasn't been tampered with
            string tamperedPayload = "{\"invoiceId\":\"INV-999\",\"status\":\"refunded\"}"; // Hacker intercepted!
            
            bool isOriginalValid = VerifyHmacSignature(payloadFromStripe, signature, sharedSecretKey);
            bool isTamperedValid = VerifyHmacSignature(tamperedPayload, signature, sharedSecretKey);

            Console.WriteLine($"Original Payload Valid? {isOriginalValid}");
            Console.WriteLine($"Tampered Payload Valid? {isTamperedValid}"); // Will fail!
        }

        static string GenerateHmacSignature(string payload, string secret)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

            using HMACSHA256 hmac = new(keyBytes);
            byte[] hashBytes = hmac.ComputeHash(payloadBytes);
            return Convert.ToBase64String(hashBytes);
        }

        static bool VerifyHmacSignature(string payload, string providedSignature, string secret)
        {
            string calculatedSignature = GenerateHmacSignature(payload, secret);
            return calculatedSignature == providedSignature;
        }
    }
}