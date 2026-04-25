using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Threading.Tasks;

namespace AdvancedTesting
{
    // 281. Integration Testing with WebApplicationFactory.
    // Instead of testing a single method, this spins up your entire API 
    // in-memory to test how the controllers, logic, and database work together.
    
    public class SiteApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public SiteApiTests(WebApplicationFactory<Program> factory) => _factory = factory;

        [Fact]
        public async Task GetSiteStatus_ReturnsSuccess()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/site/status?id=1");
            
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}