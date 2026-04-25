using System;

namespace StaticClassDemo
{
    // ==========================================================
    // 1. THE STATIC CLASS
    // ==========================================================
    // The 'static' keyword is applied to the class itself.
    public static class TemperatureConverter
    {
        // Rule: Inside a static class, ALL fields and properties MUST be static.
        public static double AbsoluteZeroCelsius { get; } = -273.15;

        // Rule: ALL methods MUST be static.
        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9.0 / 5.0) + 32.0;
        }

        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32.0) * 5.0 / 9.0;
        }

        // Rule: A static class CANNOT have a standard constructor.
        // It can only have a static constructor (which takes no parameters).
        static TemperatureConverter()
        {
            Console.WriteLine("[System: TemperatureConverter utility initialized in memory.]\n");
        }
    }

    // ==========================================================
    // MAIN EXECUTION
    // ==========================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Static Class Demo ---\n");

            // ERROR: If you uncomment the line below, it will NOT compile.
            // "Cannot declare a variable of static type 'TemperatureConverter'"
            // TemperatureConverter myConverter = new TemperatureConverter();

            // Instead, we access the methods directly via the Class Name.
            // Notice the static constructor runs automatically the very first time we touch the class!
            
            double currentTempCelsius = 25.0;
            double convertedTemp = TemperatureConverter.CelsiusToFahrenheit(currentTempCelsius);

            Console.WriteLine($"Conversion Result: {currentTempCelsius}°C is equal to {convertedTemp}°F");

            // Accessing a static property
            Console.WriteLine($"Scientific Fact: Absolute zero is {TemperatureConverter.AbsoluteZeroCelsius}°C");

            Console.WriteLine("\n--- End of Demo ---");
        }
    }
}