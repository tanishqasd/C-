using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly; // Requires Polly NuGet package

namespace AdvancedCSharp
{
    // 254. Retry Policies with Polly
    // Cloud networks are unreliable. If a microservice call fails, it might just be a microsecond network blip.
    // Polly allows you to elegantly configure automatic retries with exponential backoff.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- Polly Retry Policy ---");

            // Define a policy: Retry up to 3 times, waiting 1s, 2s, and 4s between retries.
            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => 
                {
                    Console.WriteLine($"[Polly] Network error. Retrying attempt {retryAttempt}...");
                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)); // Exponential backoff
                });

            var client = new HttpClient();

            try
            {
                // Execute the HTTP call wrapped inside the Polly policy
                await retryPolicy.ExecuteAsync(async () =>
                {
                    Console.WriteLine("Pinging external vendor API...");
                    var response = await client.GetAsync("https://this-api-does-not-exist.com");
                    response.EnsureSuccessStatusCode();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOperation ultimately failed after all retries: {ex.Message}");
            }
        }
    }
}