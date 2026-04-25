using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR; // Built into ASP.NET Core
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

// 1. Define the Hub (The central router for real-time messages)
public class SiteAlertHub : Hub
{
    // Clients will connect to this hub and call this method
    public async Task SendEmergencyAlert(string user, string message)
    {
        // Broadcast the message instantly to ALL connected clients (e.g., browser dashboards)
        await Clients.All.SendAsync("ReceiveAlert", user, message);
    }
}

var builder = WebApplication.CreateBuilder(args);

// 2. Add SignalR Services
builder.Services.AddSignalR();

var app = builder.Build();

// 3. Map the Hub to an endpoint
app.MapHub<SiteAlertHub>("/site-alerts");

// A simple API endpoint to trigger a broadcast from the server side
app.MapPost("/api/trigger-alert", async (IHubContext<SiteAlertHub> context) =>
{
    await context.Clients.All.SendAsync("ReceiveAlert", "SystemAdmin", "Weather warning: Secure all heavy machinery.");
    return "Alert broadcasted!";
});

app.Run();