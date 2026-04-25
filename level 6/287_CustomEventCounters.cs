using System.Diagnostics.Tracing;

namespace AdvancedTesting
{
    // 287. Custom EventCounters.
    // Provides high-performance live metrics that can be read by external tools 
    // like 'dotnet-counters'. Perfect for tracking "Bags of Cement Processed per Second."

    [EventSource(Name = "ConstructionSite-Metrics")]
    public sealed class SiteMetrics : EventSource
    {
        public static readonly SiteMetrics Log = new();
        private IncrementingEventCounter _materialCounter;

        private SiteMetrics()
        {
            _materialCounter = new IncrementingEventCounter("material-processed-count", this)
            {
                DisplayName = "Material Processed",
                DisplayRateTimeSpan = TimeSpan.FromSeconds(1)
            };
        }

        public void MaterialProcessed() => _materialCounter.Increment();
    }
}