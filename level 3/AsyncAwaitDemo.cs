using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting download...");
        await DownloadFileAsync();
        Console.WriteLine("Download finished!");
    }

    static async Task DownloadFileAsync()
    {
        // Simulates a 2-second background operation without blocking the main thread
        await Task.Delay(2000); 
    }
}