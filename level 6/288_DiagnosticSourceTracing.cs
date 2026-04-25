using System.Diagnostics;

namespace AdvancedTesting
{
    // 288. DiagnosticSource and Activity (Tracing).
    // Activity allows you to "time" specific spans of logic and pass 
    // that trace ID to other microservices for global observability.

    public class SiteProcessor
    {
        private static readonly ActivitySource _source = new("Construction.SiteProcessor");

        public void ProcessDailyLogs()
        {
            using var activity = _source.StartActivity("CalculatePayroll");
            activity?.SetTag("site.id", "Mumbai_01");
            
            // Logic execution...
            Thread.Sleep(100); // Simulating work
            
            activity?.SetStatus(ActivityStatusCode.Ok);
        }
    }
}