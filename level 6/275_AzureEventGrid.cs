using Azure;
using Azure.Messaging.EventGrid;
using System.Threading.Tasks;

namespace CloudNative
{
    // 275. Azure Event Grid Publishing.
    // Publishes "Events" to the cloud. Other apps (like mobile notifications or 
    // analytics) "subscribe" to these events to react in real-time.

    public class EventGridPublisher
    {
        public async Task PublishSiteAlert(string alertMessage)
        {
            EventGridPublisherClient client = new(new Uri("your-topic-endpoint"), new AzureKeyCredential("your-key"));

            EventGridEvent egEvent = new(
                "Site/Safety/Alert",
                "SafetyAlert",
                "1.0",
                new { Message = alertMessage, Severity = "High" }
            );

            await client.SendEventAsync(egEvent);
        }
    }
}