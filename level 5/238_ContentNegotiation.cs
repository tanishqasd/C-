using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 238. Content Negotiation (JSON/XML)
    // Most modern apps use JSON. However, enterprise integrations (like legacy banking 
    // or older vendor supply chain systems) strictly require XML. 
    // Content Negotiation lets the API dynamically return JSON or XML depending on what the client asks for.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure controllers to respect the "Accept" header from the client
            builder.Services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true; // Returns a 406 error if requested format is unsupported
            })
            .AddXmlSerializerFormatters(); // Enable XML support

            var app = builder.Build();

            app.MapControllers();

            Console.WriteLine("--- Content Negotiation Configured ---");
            Console.WriteLine("Clients can now send 'Accept: application/xml' to receive XML instead of JSON.");
            // app.Run();
        }
    }
}