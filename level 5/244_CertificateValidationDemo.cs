using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    // 244. X.509 Certificate Validation
    // When your API communicates with an IoT device on the construction site (like a biometric turnstile), 
    // you can require the device to present a physical SSL/TLS certificate (mTLS). 
    // This code shows how to manually validate that certificate.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- X.509 Certificate Validation ---");

            // Create an HttpClient handler that intercepts the server's certificate
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
                {
                    Console.WriteLine($"Intercepted Certificate Subject: {cert.Subject}");
                    Console.WriteLine($"Issuer: {cert.Issuer}");
                    Console.WriteLine($"Expiration: {cert.NotAfter}");

                    // Custom logic: Only trust certificates issued by our internal company CA
                    if (cert.Issuer.Contains("MyConstructionCompanyCA"))
                    {
                        return true; 
                    }

                    // For this demo, we will accept standard valid certs (errors == None)
                    return errors == System.Net.Security.SslPolicyErrors.None;
                }
            };

            using var client = new HttpClient(handler);
            
            try
            {
                Console.WriteLine("Pinging secure endpoint...");
                var response = await client.GetAsync("https://www.google.com");
                Console.WriteLine($"Response: {response.StatusCode} (Certificate was validated)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Certificate validation failed: {ex.Message}");
            }
        }
    }
}