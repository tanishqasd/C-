using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread t = new Thread(PrintNumbers);
        t.Start(); // Starts execution on a separate thread

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Main Thread: {i}");
            Thread.Sleep(500);
        }
    }

    static void PrintNumbers()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Worker Thread: {i}");
            Thread.Sleep(500);
        }
    }
}