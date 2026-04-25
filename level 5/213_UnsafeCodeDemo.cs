using System;

namespace AdvancedCSharp
{
    // 213. Unsafe Code and Pointers
    // C# normally protects you from memory management. Marking a block as 'unsafe' 
    // lets you use C++ style pointers for extreme performance, often used in graphics 
    // or hardware manipulation.
    // Note: You must enable "Allow unsafe code" in your project's .csproj file.

    class Program
    {
        // Method must be marked unsafe to use pointers
        static unsafe void Main()
        {
            Console.WriteLine("--- Unsafe Code & Pointers ---");

            int number = 1042;

            // Use the address-of operator (&) to get the memory address
            int* pointerToNumber = &number;

            Console.WriteLine($"Original Value: {number}");
            Console.WriteLine($"Memory Address: {(long)pointerToNumber:X}");

            // Dereference the pointer (*) to change the value directly in memory
            *pointerToNumber = 9999;

            Console.WriteLine($"New Value via Pointer: {number}");
        }
    }
}