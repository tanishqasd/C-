using System;

namespace AdvancedCSharp
{
    // 201. Record Types provide immutable data models with value-based equality.
    // They are perfect for transferring data securely between a C# backend and a React frontend.
    
    // This single line creates a fully immutable class with properties, a constructor, and value-equality logic.
    public record MaterialDelivery(string TrackingId, string MaterialType, int Quantity, decimal TotalCost);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Record Types Demo ---");

            var delivery1 = new MaterialDelivery("TRK-100", "Cement", 500, 15000.00m);
            
            // "with" expression creates a non-destructive copy with modified values
            var delivery2 = delivery1 with { TrackingId = "TRK-101", Quantity = 600 };
            var delivery3 = new MaterialDelivery("TRK-100", "Cement", 500, 15000.00m);

            Console.WriteLine(delivery1);
            Console.WriteLine(delivery2);
            
            // Evaluates to TRUE because records check the actual values, not the memory reference
            Console.WriteLine($"Delivery 1 equals Delivery 3? {delivery1 == delivery3}"); 
        }
    }
}