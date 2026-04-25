using System;

namespace CloudNative
{
    // 280. Grafana Dashboard Integration.
    // Grafana doesn't need C# code directly; it consumes the Prometheus /metrics 
    // endpoint from File 279 to build visual dashboards.
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- Grafana & Monitoring Pipeline ---");
            Console.WriteLine("1. C# App exports metrics via Prometheus library.");
            Console.WriteLine("2. Prometheus Server scrapes the /metrics endpoint.");
            Console.WriteLine("3. Grafana connects to Prometheus to visualize 'Material Usage vs Budget'.");
        }
    }
}