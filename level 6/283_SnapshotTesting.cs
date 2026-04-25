using VerifyXunit;
using Xunit;

namespace AdvancedTesting
{
    // 283. Snapshot Testing (Verify).
    // Instead of writing 50 Assert statements for a large JSON object, 
    // Snapshot testing takes a "photo" of the output and fails if a single character changes.
    
    [UsesVerify]
    public class ReportTests
    {
        [Fact]
        public Task VerifySiteReport_Snapshot()
        {
            var complexReport = new { 
                Site = "Alpha", 
                Budget = 500000, 
                Managers = new[] { "Tanishqa", "Admin" } 
            };

            return Verifier.Verify(complexReport); // Compares against a saved .verified file
        }
    }
}