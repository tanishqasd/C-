using System;

// Event-Driven Architecture allows different parts of a system to react to things 
// happening without being directly connected to each other (extreme decoupling).

// 1. The Event (A simple record of something that happened in the past)
public class MaterialOrderedEvent
{
    public string Material { get; set; }
    public int Quantity { get; set; }
}

// 2. The Event Bus (The central router)
public static class EventBus
{
    // Other classes can subscribe to this Action
    public static event Action<MaterialOrderedEvent> OnMaterialOrdered;

    public static void Publish(MaterialOrderedEvent ev)
    {
        Console.WriteLine($"[EventBus] Broadcasting: {ev.Quantity} units of {ev.Material} ordered...\n");
        OnMaterialOrdered?.Invoke(ev); // Triggers all subscribers
    }
}

// 3. Subscribers (Independent modules listening for events)
public class InventoryModule
{
    public InventoryModule() => EventBus.OnMaterialOrdered += Handle;
    
    private void Handle(MaterialOrderedEvent ev) 
    {
        Console.WriteLine($" -> [Inventory Module] Deducting {ev.Quantity} {ev.Material} from virtual stock.");
    }
}

public class FinanceModule
{
    public FinanceModule() => EventBus.OnMaterialOrdered += Handle;
    
    private void Handle(MaterialOrderedEvent ev) 
    {
        Console.WriteLine($" -> [Finance Module] Calculating ledger costs for {ev.Material}.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Event-Driven Architecture Demo ---\n");
        
        // Boot up the independent modules (they automatically subscribe)
        var inventory = new InventoryModule();
        var finance = new FinanceModule();

        // The UI/API only cares about publishing the event. It has NO IDEA 
        // that the Inventory and Finance modules even exist!
        var newOrder = new MaterialOrderedEvent { Material = "Steel Beams", Quantity = 50 };
        EventBus.Publish(newOrder);
    }
}