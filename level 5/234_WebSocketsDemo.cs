using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AdvancedCSharp
{
    // 234. WebSockets for Live Dashboards
    // REST APIs are "pull" only (the client has to ask for data). 
    // WebSockets keep a permanent, two-way connection open. This is how you build 
    // a live map showing delivery trucks moving toward the construction site in real-time.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Enable WebSockets on the server
            app.UseWebSockets();

            app.Map("/live-truck-tracking", async context =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    // Accept the connection
                    using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await PushLiveLocationData(webSocket);
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            });

            Console.WriteLine("--- WebSocket Server Ready ---");
            // app.Run();
        }

        static async Task PushLiveLocationData(WebSocket webSocket)
        {
            var random = new Random();
            
            // Keep sending data until the client closes the connection
            while (webSocket.State == WebSocketState.Open)
            {
                string locationUpdate = $"Truck 4A is at Lat: {random.Next(18, 20)}.{random.Next(1000, 9999)}, Lng: 75.32";
                var buffer = Encoding.UTF8.GetBytes(locationUpdate);

                // Push data to the connected frontend dashboard
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer), 
                    WebSocketMessageType.Text, 
                    true, 
                    CancellationToken.None);

                // Wait 2 seconds before sending the next GPS ping
                await Task.Delay(2000); 
            }
        }
    }
}