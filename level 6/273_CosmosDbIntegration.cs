using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace CloudNative
{
    // 273. Azure Cosmos DB Integration.
    // A globally distributed NoSQL database. Essential for projects spanning multiple 
    // countries where you need sub-millisecond data access.

    public class CosmosService
    {
        private static readonly string EndpointUri = "https://your-account.documents.azure.com:443/";
        private static readonly string PrimaryKey = "your-primary-key";

        public async Task AddSiteLogAsync(dynamic logEntry)
        {
            using CosmosClient client = new(EndpointUri, PrimaryKey);
            Database database = await client.CreateDatabaseIfNotExistsAsync("ConstructionData");
            Container container = await database.CreateContainerIfNotExistsAsync("SiteLogs", "/partitionKey");

            await container.CreateItemAsync(logEntry, new PartitionKey(logEntry.partitionKey));
        }
    }
}