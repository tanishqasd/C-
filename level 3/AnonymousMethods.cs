using System;

class Program
{
    delegate void Greet(string name);

    static void Main()
    {
        // Anonymous method using the 'delegate' keyword (older style before lambdas)
        Greet greetUser = delegate (string name)
        {
            Console.WriteLine($"Hello, {name}!");
        };

        greetUser("Tanishqa");
    }
}