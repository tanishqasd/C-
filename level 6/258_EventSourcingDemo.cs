using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharp
{
    // 258. Event Sourcing (Basic Implementation)
    // Instead of storing the CURRENT state of an object (e.g., Stock = 50), 
    // Event Sourcing stores every EVENT that ever happened (Added 100, Removed 20, Removed 30).
    // The current state is calculated by replaying the events. This provides an unhackable audit trail.

    public abstract class Event { public DateTime Timestamp { get; set; } = DateTime.UtcNow; }
    public class MaterialDelivered : Event { public int Quantity { get; set; } }
    public class MaterialUsed : Event { public int Quantity { get; set; } }

    public class MaterialInventory
    {
        private int _currentStock = 0;
        private readonly List<Event> _changes = new();

        public int CurrentStock => _currentStock;
        public IReadOnlyList<Event> AuditTrail => _changes.AsReadOnly();

        public void Apply(Event @event)
        {
            _changes.Add(@event);
            if (@event is MaterialDelivered d) _currentStock += d.Quantity;
            if (@event is MaterialUsed u) _currentStock -= u.Quantity;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Event Sourcing ---");

            var cementInventory = new MaterialInventory();

            // Replaying history
            cementInventory.Apply(new MaterialDelivered { Quantity = 500 }); // Monday
            cementInventory.Apply(new MaterialUsed { Quantity = 100 });      // Tuesday
            cementInventory.Apply(new MaterialUsed { Quantity = 50 });       // Wednesday

            Console.WriteLine($"Calculated Current Stock: {cementInventory.CurrentStock}");
            Console.WriteLine($"Total Events in Audit Trail: {cementInventory.AuditTrail.Count}");
        }
    }
}