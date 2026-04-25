using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FinalIntegrations
{
    // 291. SignalR with React Client.
    // This Hub allows your C# server to "push" live updates to the React frontend.
    // Perfect for showing a live notification when a material shipment arrives.
    
    public class SiteNotificationHub : Hub
    {
        public async Task SendSiteAlert(string message)
        {
            // Broadcasts to all connected React clients
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}