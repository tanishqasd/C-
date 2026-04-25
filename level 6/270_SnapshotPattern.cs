using System;
using System.Collections.Generic;

namespace Level5_DDD
{
    // 270. Snapshotting Domain State (Memento Pattern).
    // In Event Sourcing, replaying 1 million events to get current state is slow. 
    // A "Snapshot" saves the state every 100 events to speed up recovery.

    public record InventorySnapshot(int StockLevel, DateTime Timestamp);

    public class InventoryAggregate
    {
        public int Stock { get; set; }
        public InventorySnapshot CreateSnapshot() => new(Stock, DateTime.Now);
        public void Restore(InventorySnapshot snapshot) => Stock = snapshot.StockLevel;
    }

    class Program
    {
        static void Main()
        {
            var inv = new InventoryAggregate { Stock = 500 };
            var snapshot = inv.CreateSnapshot(); // Save point
            
            inv.Stock = 0; // Disaster happens
            inv.Restore(snapshot); // Fast recovery
            
            Console.WriteLine($"Inventory restored to snapshot: {inv.Stock}");
        }
    }
}