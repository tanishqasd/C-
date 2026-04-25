using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    // Best practice: Re-use HttpClient instances to avoid socket exhaustion
    private static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
        Console.WriteLine("--- API Consumption using HttpClient ---");
        Console.WriteLine("Fetching data from a public REST API...\n");

        string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";

        try
        {
            // Send GET request asynchronously
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            
            // Ensure we got a successful status code (like 200 OK)
            response.EnsureSuccessStatusCode();

            // Read the JSON response as a string
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response Received:");
            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine($"Message: {e.Message}");
        }
    }
}