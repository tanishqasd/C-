using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace AdvancedCSharp
{
    // 260. Distributed Caching (Redis Integration)
    // Standard IMemoryCache stores data in the RAM of one specific server. 
    // If you have 5 servers running your API, they don't share memory. 
    // IDistributedCache (backed by Redis) ensures all 5 servers access the exact same cached data.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Redis as the backing store for IDistributedCache
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "ConstructionApp_";
            });

            var app = builder.Build();

            app.MapGet("/api/site-weather", async (IDistributedCache cache) =>
            {
                string cacheKey = "weather_mumbai";
                
                // Try to get from distributed cache first
                byte[] cachedData = await cache.GetAsync(cacheKey);
                if (cachedData != null)
                {
                    return Encoding.UTF8.GetString(cachedData) + " [From Redis Cache]";
                }

                // Simulate slow external API call
                string freshData = "Sunny, 32C";
                
                // Save back to distributed cache for other servers to use
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                await cache.SetAsync(cacheKey, Encoding.UTF8.GetBytes(freshData), options);

                return freshData + " [Fetched Fresh & Cached]";
            });

            Console.WriteLine("--- Distributed Caching Configured ---");
            // app.Run();
        }
    }
}