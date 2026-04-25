using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;
using System.Security.Claims;

namespace AdvancedTesting
{
    // 284. Mocking HttpContext.
    // When testing code that depends on the "Current User," you must mock 
    // the HttpContext to simulate a logged-in Site Manager.
    
    public class SecurityServiceTests
    {
        [Fact]
        public void CheckAccess_SiteManager_ReturnsTrue()
        {
            var mockContext = new Mock<IHttpContextAccessor>();
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { 
                new Claim(ClaimTypes.Role, "SiteManager") 
            }));

            mockContext.Setup(x => x.HttpContext.User).Returns(user);
            
            // Logic being tested:
            bool hasAccess = user.IsInRole("SiteManager");
            Assert.True(hasAccess);
        }
    }
}