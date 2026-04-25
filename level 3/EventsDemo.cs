using System;

class ProcessBusinessLogic
{
    // Declare the event
    public event EventHandler ProcessCompleted;

    public void StartProcess()
    {
        Console.WriteLine("Process Started...");
        // Trigger the event
        ProcessCompleted?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // Subscribe to event
        bl.StartProcess();
    }

    // Event handler method
    static void bl_ProcessCompleted(object sender, EventArgs e)
    {
        Console.WriteLine("Process Completed Event Received!");
    }
}