using System;
using System.Numerics;

namespace AdvancedCSharp
{
    // 220. SIMD Hardware Acceleration
    // SIMD (Single Instruction, Multiple Data) allows your CPU to perform the exact same 
    // mathematical operation on multiple numbers simultaneously. This is heavily used in 
    // 3D rendering for site modeling, or calculating structural load stress across arrays of data.

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- SIMD Hardware Acceleration ---");

            // Check if the server's CPU actually supports SIMD Vectors
            if (!Vector.IsHardwareAccelerated)
            {
                Console.WriteLine("Hardware acceleration not supported on this machine.");
                return;
            }

            Console.WriteLine($"Vector Size: {Vector<float>.Count} floats processed per CPU cycle.");

            // Scenario: Adding weight loads to a structural beam
            float[] structuralLoadsA = { 1.5f, 2.2f, 3.1f, 4.0f, 5.5f, 6.1f, 7.8f, 8.2f };
            float[] structuralLoadsB = { 0.5f, 0.8f, 1.1f, 1.0f, 0.5f, 1.1f, 0.2f, 0.8f };
            float[] combinedStress = new float[8];

            // Load data into SIMD Vectors
            var vectorA = new Vector<float>(structuralLoadsA);
            var vectorB = new Vector<float>(structuralLoadsB);

            // CPU executes this addition for ALL elements at the exact same time!
            var resultVector = Vector.Add(vectorA, vectorB);

            // Copy the result back to our standard array
            resultVector.CopyTo(combinedStress);

            Console.WriteLine("\nCombined Stress Results:");
            for (int i = 0; i < combinedStress.Length; i++)
            {
                Console.WriteLine($"Point {i}: {combinedStress[i]} tons");
            }
        }
    }
}