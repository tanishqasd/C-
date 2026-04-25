using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Executing Parallel For Loop:");

        // Executes iterations concurrently across available CPU cores
        Parallel.For(0, 10, i =>
        {
            Console.WriteLine($"Task {i} executed on thread {Task.CurrentId}");
        });
    }
}