using System;

namespace SolidPrinciplesDemo
{
    // ========================================================================
    // 1. Single Responsibility Principle (SRP)
    // A class should have only one reason to change.
    // ========================================================================
    public class Order
    {
        public string ItemName { get; set; }
        public double Amount { get; set; }
    }

    // GOOD: Saving to a database is a separate responsibility.
    public class OrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine($"[SRP] Saving {order.ItemName} to the database.");
        }
    }

    // GOOD: Printing an invoice is a separate responsibility.
    public class InvoicePrinter
    {
        public void PrintInvoice(Order order)
        {
            Console.WriteLine($"[SRP] Printing invoice for {order.ItemName}: ${order.Amount}");
        }
    }

    // ========================================================================
    // 2. Open/Closed Principle (OCP)
    // Software entities should be open for extension, but closed for modification.
    // ========================================================================
    public interface IDiscountStrategy
    {
        double ApplyDiscount(double amount);
    }

    // By using an interface, we can add new discount types in the future 
    // (like HolidayDiscount or EmployeeDiscount) without EVER changing existing code!
    public class StandardDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double amount) => amount; // No discount
    }

    public class VIPDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double amount) => amount * 0.8; // 20% off
    }

    // ========================================================================
    // 3. Liskov Substitution Principle (LSP)
    // Derived classes must be substitutable for their base classes.
    // ========================================================================
    public abstract class DeliveryService
    {
        public abstract void DeliverItem();
    }

    public class PostalDelivery : DeliveryService
    {
        public override void DeliverItem()
        {
            Console.WriteLine("[LSP] Delivering physical package via postal network.");
        }
    }

    // Note: If we had a "DigitalDownload" item, we would NOT inherit from DeliveryService 
    // if DeliveryService strictly implies trucks and physical addresses. Forcing a digital 
    // item to implement a "GetTruckRoute()" method would violate LSP.

    // ========================================================================
    // 4. Interface Segregation Principle (ISP)
    // Clients should not be forced to depend on interfaces they do not use.
    // ========================================================================
    // BAD: IWorker { void Work(); void Eat(); } -> A Robot shouldn't be forced to Eat().

    // GOOD: Small, segregated interfaces
    public interface IWorkable
    {
        void Work();
    }

    public interface IFeedable
    {
        void Eat();
    }

    public class HumanWorker : IWorkable, IFeedable
    {
        public void Work() => Console.WriteLine("[ISP] Human warehouse worker is packing boxes.");
        public void Eat() => Console.WriteLine("[ISP] Human worker is on a lunch break.");
    }

    public class RobotWorker : IWorkable
    {
        public void Work() => Console.WriteLine("[ISP] Automated robot is packing boxes. No food needed.");
        // The robot gracefully ignores IFeedable.
    }

    // ========================================================================
    // 5. Dependency Inversion Principle (DIP)
    // High-level modules should depend on abstractions (interfaces), not concretions.
    // ========================================================================
    public interface INotificationService
    {
        void SendNotification(string message);
    }

    public class EmailService : INotificationService
    {
        public void SendNotification(string message) => Console.WriteLine($"[DIP] Email sent: {message}");
    }

    public class SmsService : INotificationService
    {
        public void SendNotification(string message) => Console.WriteLine($"[DIP] SMS sent: {message}");
    }

    // OrderProcessor (High Level) depends on INotificationService (Abstraction).
    // It does NOT care if you use Email or SMS, as long as it fulfills the contract.
    public class OrderProcessor
    {
        private readonly INotificationService _notificationService;

        // The specific service is "injected" through the constructor
        public OrderProcessor(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Process(Order order)
        {
            Console.WriteLine($"[DIP] Processing order for {order.ItemName}...");
            _notificationService.SendNotification("Your order has been processed successfully.");
        }
    }

    // ========================================================================
    // MAIN EXECUTION
    // ========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SOLID Principles Demo ---\n");

            // 1. SRP Execution
            Order myOrder = new Order { ItemName = "MacBook Pro", Amount = 2500 };
            OrderRepository repo = new OrderRepository();
            InvoicePrinter printer = new InvoicePrinter();
            repo.Save(myOrder);
            printer.PrintInvoice(myOrder);
            Console.WriteLine();

            // 2. OCP Execution
            IDiscountStrategy vipDiscount = new VIPDiscount();
            Console.WriteLine($"[OCP] Original: ${myOrder.Amount}, VIP Price: ${vipDiscount.ApplyDiscount(myOrder.Amount)}\n");

            // 3. LSP Execution
            DeliveryService delivery = new PostalDelivery();
            delivery.DeliverItem();
            Console.WriteLine();

            // 4. ISP Execution
            HumanWorker human = new HumanWorker();
            RobotWorker robot = new RobotWorker();
            human.Work(); 
            human.Eat();
            robot.Work();
            Console.WriteLine();

            // 5. DIP Execution (We can easily swap EmailService for SmsService here!)
            INotificationService emailNotifier = new EmailService();
            OrderProcessor processor = new OrderProcessor(emailNotifier);
            processor.Process(myOrder);

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}