using System;
using Microsoft.Extensions.DependencyInjection; // Requires NuGet package

// 1. Define the Contract (Interface)
public interface IMessageService
{
    void SendMessage(string message);
}

// 2. Implement the Contract
public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"[Email Service] Sending: {message}");
    }
}

public class Application
{
    private readonly IMessageService _messageService;

    // The dependency is "injected" through the constructor
    public Application(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Run()
    {
        _messageService.SendMessage("Hello via Dependency Injection!");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Dependency Injection Demo ---");

        // Setup the Dependency Injection Container
        var serviceProvider = new ServiceCollection()
            .AddTransient<IMessageService, EmailService>() // Map interface to implementation
            .AddTransient<Application>()                   // Register the main app
            .BuildServiceProvider();

        // Resolve the application and run it
        var app = serviceProvider.GetService<Application>();
        app.Run();
    }
}