using System;
using Polly;

namespace AdvancedCSharp
{
    // 255. Circuit Breaker Pattern with Polly
    // If a vendor API is completely down, hitting it with retries over and over will exhaust your server's resources.
    // A Circuit Breaker detects the failure, "trips" (opens the circuit), and instantly fails future calls 
    // for a set time period to give the vendor time to recover.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Polly Circuit Breaker ---");

            // Policy: If 2 consecutive failures occur, break the circuit for 5 seconds.
            var circuitBreaker = Policy
                .Handle<Exception>()
                .CircuitBreaker(
                    exceptionsAllowedBeforeBreaking: 2,
                    durationOfBreak: TimeSpan.FromSeconds(5),
                    onBreak: (ex, breakDelay) => Console.WriteLine($"\n[CIRCUIT OPENED] Vendor API is down. Pausing calls for {breakDelay.TotalSeconds} seconds."),
                    onReset: () => Console.WriteLine("\n[CIRCUIT CLOSED] Vendor API recovered. Resuming traffic."),
                    onHalfOpen: () => Console.WriteLine("\n[CIRCUIT HALF-OPEN] Testing if Vendor API is back online...")
                );

            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine($"\nRequest {i}: Attempting to process payment...");
                    circuitBreaker.Execute(() => throw new Exception("Vendor timeout")); // Simulating failure
                }
                catch (Polly.CircuitBreaker.BrokenCircuitException)
                {
                    Console.WriteLine($"Request {i}: FAILING FAST. Circuit is broken. Did not waste time attempting network call.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Request {i}: Failed. ({ex.Message})");
                }
            }
        }
    }
}