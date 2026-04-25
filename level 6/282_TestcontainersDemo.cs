using Testcontainers.MsSql;
using Xunit;

namespace AdvancedTesting
{
    // 282. Testcontainers (Spinning up Docker in Tests).
    // Instead of using a fake "in-memory" database, Testcontainers automatically 
    // launches a real SQL Server inside a Docker container for your tests.
    
    public class DatabaseTests : IAsyncLifetime
    {
        private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();

        public async Task InitializeAsync() => await _msSqlContainer.StartAsync();
        public async Task DisposeAsync() => await _msSqlContainer.StopAsync();

        [Fact]
        public void Connection_To_Real_Sql_Container_Works()
        {
            string connectionString = _msSqlContainer.GetConnectionString();
            Assert.NotNull(connectionString);
        }
    }
}