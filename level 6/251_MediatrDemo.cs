using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 251. MediatR (CQRS and Mediator Pattern)
    // The Mediator pattern forces objects to communicate through a central hub instead of 
    // directly talking to each other. This heavily decouples your API controllers from your business logic.

    // 1. The Command (Data)
    public record CreateSiteCommand(string SiteName, string Location) : IRequest<int>;

    // 2. The Handler (Logic)
    public class CreateSiteHandler : IRequestHandler<CreateSiteCommand, int>
    {
        public Task<int> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[MediatR] Creating new construction site: {request.SiteName} at {request.Location}...");
            // Simulate DB insert and returning new ID
            return Task.FromResult(99); 
        }
    }

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("--- MediatR Pattern ---");

            var services = new ServiceCollection();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            var provider = services.BuildServiceProvider();

            var mediator = provider.GetRequiredService<IMediator>();

            // The sender has ZERO knowledge of the CreateSiteHandler class!
            int newSiteId = await mediator.Send(new CreateSiteCommand("Project Titan", "Mumbai"));
            Console.WriteLine($"Site created successfully with ID: {newSiteId}");
        }
    }
}