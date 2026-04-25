using System;

namespace AdvancedCSharp
{
    // 216. ref structs and 'in' parameters
    // A 'ref struct' guarantees that the object is allocated strictly on the Stack, NEVER the Heap. 
    // This entirely avoids the Garbage Collector. The 'in' parameter passes data by reference 
    // but makes it read-only, preventing accidental modifications while saving memory.

    // Perfect for high-frequency telemetry data from construction site sensors.
    public ref struct SensorReading
    {
        public ReadOnlySpan<char> DeviceId;
        public double Temperature;
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- ref struct & in Parameters ---");

            string rawData = "TEMP_SENSOR_492:45.5";
            var reading = new SensorReading
            {
                DeviceId = rawData.AsSpan(0, 15),
                Temperature = 45.5
            };

            ProcessReading(in reading);
        }

        // The 'in' keyword means we pass the struct by reference (fast) 
        // but cannot modify it inside this method (safe).
        static void ProcessReading(in SensorReading reading)
        {
            // reading.Temperature = 50.0; // ERROR: Cannot assign to variable 'in'
            
            Console.WriteLine($"Processed Device: {reading.DeviceId.ToString()}");
            Console.WriteLine($"Temperature: {reading.Temperature}°C");
        }
    }
}