using System;

class AccessSpecifiersDemo
{
    // Public - accessible from anywhere
    public string publicVar = "Public - accessible everywhere";

    // Private - accessible only within this class
    private string privateVar = "Private - only within this class";

    // Protected - accessible within this class and derived classes
    protected string protectedVar = "Protected - in this class and derived classes";

    // Internal - accessible within the same assembly
    internal string internalVar = "Internal - within same assembly";

    // Protected Internal - accessible within same assembly or derived classes
    protected internal string protectedInternalVar = "Protected Internal - assembly or derived classes";

    public void DisplayAll()
    {
        Console.WriteLine(publicVar);
        Console.WriteLine(privateVar);
        Console.WriteLine(protectedVar);
        Console.WriteLine(internalVar);
        Console.WriteLine(protectedInternalVar);
    }
}

class DerivedClass : AccessSpecifiersDemo
{
    public void ShowProtected()
    {
        // Can access protected and protected internal
        Console.WriteLine(protectedVar);
        Console.WriteLine(protectedInternalVar);
    }
}

class Program
{
    static void Main()
    {
        AccessSpecifiersDemo obj = new AccessSpecifiersDemo();
        obj.DisplayAll();

        DerivedClass derived = new DerivedClass();
        derived.ShowProtected();
    }
}