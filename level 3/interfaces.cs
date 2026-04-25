using System;
using System.Collections.Generic;

namespace InterfaceDemo
{
    // 1. THE INTERFACE (The Contract)
    // Conventionally, interface names in C# always start with an 'I'.
    // Notice there are no curly braces {} or method bodies here, just the signature.
    interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    // 2. IMPLEMENTATION A (Fulfilling the Contract)
    // The colon (:) means this class agrees to implement IPaymentProcessor.
    class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}...");
            Console.WriteLine("Connecting to the banking network... Transaction Approved.");
        }
    }

    // 3. IMPLEMENTATION B (Fulfilling the Contract differently)
    class PayPalProcessor : IPaymentProcessor
    {
        private string _emailAddress;

        public PayPalProcessor(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        // PayPal handles the payment entirely differently than a Credit Card,
        // but it still perfectly satisfies the IPaymentProcessor contract.
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount} for account: {_emailAddress}...");
            Console.WriteLine("Authenticating with PayPal servers... Transaction Approved.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Interfaces Demo ---\n");

            // Because both classes implement IPaymentProcessor, we can store 
            // them in variables of the interface type.
            IPaymentProcessor payment1 = new CreditCardProcessor();
            IPaymentProcessor payment2 = new PayPalProcessor("tanishqa@example.com");

            // We can even group these entirely different objects into a single list
            // because they share the same interface contract.
            List<IPaymentProcessor> checkoutQueue = new List<IPaymentProcessor>
            {
                payment1,
                payment2
            };

            // We can process all payments uniformly without caring about the underlying logic
            foreach (IPaymentProcessor processor in checkoutQueue)
            {
                Console.WriteLine("Initiating new transaction:");
                
                // The program knows exactly which specific ProcessPayment method to call!
                processor.ProcessPayment(250.00); 
                Console.WriteLine(); 
            }

            Console.WriteLine("--- End of Demo ---");
        }
    }
}