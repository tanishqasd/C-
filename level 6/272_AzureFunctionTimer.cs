using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CloudNative
{
    // 272. Azure Functions (Timer Trigger).
    // Automatically executes code on a schedule. Perfect for 
    // "Daily Site Cleanup" tasks like archiving old material logs.

    public class SiteCleanupFunction
    {
        [Function("DailyInventoryArchive")]
        public void Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer, FunctionContext context)
        {
            var logger = context.GetLogger("DailyInventoryArchive");
            logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            // Logic to move daily material usage to long-term cloud storage
            logger.LogInformation("Archive process complete for all active sites.");
        }
    }
}