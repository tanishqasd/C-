using System;
using System.Threading;

class Program
{
    static int _counter = 0;
    static readonly object _lockObj = new object();

    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Console.WriteLine($"Final Counter (should be 2000): {_counter}");
    }

    static void Increment()
    {
        for (int i = 0; i < 1000; i++)
        {
            // Ensures only one thread can modify the counter at a time
            lock (_lockObj)
            {
                _counter++;
            }
        }
    }
}