using System;

namespace EncapsulationDemo
{
    class BankAccount
    {
        // 1. HIDDEN DATA (Private Field)
        // The '_balance' variable is private. It cannot be accessed or 
        // modified directly from outside this class.
        private double _balance;

        // Constructor
        public BankAccount(double initialBalance)
        {
            if (initialBalance >= 0)
            {
                _balance = initialBalance;
            }
            else
            {
                _balance = 0;
                Console.WriteLine("Initial balance cannot be negative. Set to 0.");
            }
        }

        // 2. CONTROLLED ACCESS (Public Property)
        // This acts as a "getter". It allows the outside world to *read* // the balance, but not *change* it directly.
        public double Balance
        {
            get { return _balance; }
        }

        // 3. CONTROLLED MODIFICATION (Public Methods)
        // These methods validate the data before allowing changes to the private field.
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Deposited: ${amount}. Current Balance: ${_balance}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrew: ${amount}. Current Balance: ${_balance}");
            }
            else
            {
                Console.WriteLine($"Failed to withdraw ${amount}. Insufficient funds or invalid amount.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Encapsulation Demo ---");

            // Create a new account
            BankAccount myAccount = new BankAccount(1000);

            // Reading data via the public property is allowed
            Console.WriteLine($"Initial Balance: ${myAccount.Balance}");

            // Modifying data via public methods (Validation passes)
            myAccount.Deposit(500);
            myAccount.Withdraw(200);

            // Attempting invalid modifications (Validation blocks it)
            myAccount.Withdraw(5000); 
            myAccount.Deposit(-50);

            // ERROR: If you uncomment the line below, the program will not compile.
            // This is encapsulation in action! The data is protected.
            // myAccount._balance = 1000000; 
            
            Console.WriteLine("--- End of Demo ---");
        }
    }
}