namespace AdvancedTesting
{
    // 290. CPU Profiling (dotnet-trace).
    // High CPU usage usually means an infinite loop or heavy mathematical 
    // calculations (like 3D rendering) are happening on the main thread.
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- CPU Profiling Strategy ---");
            Console.WriteLine("1. Use 'dotnet-trace collect' while the app is slow.");
            Console.WriteLine("2. Open the .nettrace file in 'PerfView' or Visual Studio.");
            Console.WriteLine("3. Identify the 'Hot Path' (the method taking 90% of CPU time).");
        }
    }
}