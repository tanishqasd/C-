using System;

class BankAccount
{
    public string AccountHolder { get; set; }
    private decimal _balance;

    public BankAccount(string name, decimal initialDeposit)
    {
        AccountHolder = name;
        _balance = initialDeposit;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0) { _balance += amount; Console.WriteLine($"Deposited ${amount}. New Balance: ${_balance}"); }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= _balance) { _balance -= amount; Console.WriteLine($"Withdrew ${amount}. New Balance: ${_balance}"); }
        else Console.WriteLine("Insufficient funds or invalid amount.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Console Banking System ---");
        BankAccount myAccount = new BankAccount("Tanishqa Dayma", 1000m);

        myAccount.Deposit(500m);
        myAccount.Withdraw(200m);
        myAccount.Withdraw(5000m); // Will fail gracefully
    }
}