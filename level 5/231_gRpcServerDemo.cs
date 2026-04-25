using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 231. gRPC Server Implementation
    // gRPC is an ultra-fast communication protocol developed by Google. 
    // It sends data as compressed binary rather than text (JSON), making it 
    // up to 10x faster than REST. It's perfect for microservices talking to each other.

    // Note: In a real project, this class is usually auto-generated from a .proto file.
    public class SiteEquipmentService : EquipmentProvider.EquipmentProviderBase
    {
        public override Task<EquipmentStatusReply> GetStatus(EquipmentStatusRequest request, ServerCallContext context)
        {
            // Simulate looking up heavy machinery status
            return Task.FromResult(new EquipmentStatusReply
            {
                EquipmentId = request.EquipmentId,
                IsOperational = true,
                CurrentFuelLevel = 85.5
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Register gRPC services
            builder.Services.AddGrpc();
            
            var app = builder.Build();

            // Map the gRPC endpoint
            app.MapGrpcService<SiteEquipmentService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

            Console.WriteLine("--- gRPC Server Ready ---");
            // app.Run(); 
        }
    }

    // Dummy classes representing the auto-generated Protobuf models
    public class EquipmentProvider { public class EquipmentProviderBase { public virtual Task<EquipmentStatusReply> GetStatus(EquipmentStatusRequest r, ServerCallContext c) => null; } }
    public class EquipmentStatusRequest { public string EquipmentId { get; set; } }
    public class EquipmentStatusReply { public string EquipmentId { get; set; } public bool IsOperational { get; set; } public double CurrentFuelLevel { get; set; } }
}