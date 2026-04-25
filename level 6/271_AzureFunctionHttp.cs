using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CloudNative
{
    // 271. Azure Functions (HTTP Trigger).
    // Serverless functions that trigger via HTTP. Perfect for low-cost, 
    // high-scale tasks like fetching a worker's digital ID for site entry.
    
    public class WorkerIdFunction
    {
        private readonly ILogger<WorkerIdFunction> _logger;
        public WorkerIdFunction(ILogger<WorkerIdFunction> logger) => _logger = logger;

        [Function("GetWorkerDigitalId")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            string workerId = req.Query["id"];
            _logger.LogInformation($"C# HTTP trigger processed a request for Worker: {workerId}");

            if (string.IsNullOrEmpty(workerId)) return new BadRequestObjectResult("Please pass a worker ID.");

            return new OkObjectResult(new { Id = workerId, Status = "Authorized", AccessLevel = "Full" });
        }
    }
}