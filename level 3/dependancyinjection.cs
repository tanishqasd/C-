using System;

// Interface for the dependency
public interface IGreeter
{
    void Greet(string name);
}

// Concrete implementation
public class ConsoleGreeter : IGreeter
{
    public void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}

// Class that depends on IGreeter
public class GreetingService
{
    private readonly IGreeter _greeter;

    // Dependency is injected through constructor
    public GreetingService(IGreeter greeter)
    {
        _greeter = greeter;
    }

    public void SayHello(string name)
    {
        _greeter.Greet(name);
    }
}

// Main Program
class Program
{
    static void Main()
    {
        // Create dependency
        IGreeter greeter = new ConsoleGreeter();

        // Inject dependency into service
        GreetingService service = new GreetingService(greeter);

        // Use the service
        service.SayHello("Tanishqa");
        service.SayHello("World");
    }
}