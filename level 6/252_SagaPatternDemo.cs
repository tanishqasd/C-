using System;
using System.Threading.Tasks;

namespace AdvancedCSharp
{
    // 252. Saga Pattern for Distributed Transactions
    // In microservices, you cannot use a standard SQL transaction across different databases.
    // A Saga manages a sequence of local transactions. If one step fails, the Saga executes 
    // "Compensating Transactions" to undo the previous steps.

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- Saga Pattern (Orchestration) ---");
            await ProcessMaterialOrderSaga("Cement", 1000);
        }

        static async Task ProcessMaterialOrderSaga(string material, decimal cost)
        {
            bool paymentSuccess = false;
            try
            {
                // Step 1: Reserve Inventory
                Console.WriteLine($"1. Reserving {material} in Inventory DB...");
                
                // Step 2: Charge Budget (Simulating a failure here)
                Console.WriteLine($"2. Charging ${cost} to Site Budget DB...");
                throw new Exception("Insufficient site funds!");
                
                paymentSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[SAGA FAILED]: {ex.Message}");
                // Execute Compensating Transaction to rollback Step 1
                await CompensateInventoryReservation(material);
            }
        }

        static Task CompensateInventoryReservation(string material)
        {
            Console.WriteLine($"[COMPENSATION] Releasing {material} back into general inventory pool.");
            return Task.CompletedTask;
        }
    }
}