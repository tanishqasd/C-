using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Stack: Last-In, First-Out (LIFO)
        Stack<string> stack = new Stack<string>();
        stack.Push("First");
        stack.Push("Second");
        Console.WriteLine($"Stack Pop: {stack.Pop()}"); // Outputs "Second"

        // Queue: First-In, First-Out (FIFO)
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("First");
        queue.Enqueue("Second");
        Console.WriteLine($"Queue Dequeue: {queue.Dequeue()}"); // Outputs "First"
    }
}