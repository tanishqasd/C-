using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs; // Requires Azure.Storage.Blobs NuGet package

// Azure Blob Storage is ideal for storing unstructured data like 
// construction site blueprints, worker ID photos, or scanned vendor invoices.
class Program
{
    static async Task Main()
    {
        Console.WriteLine("--- Azure Blob Storage Upload ---");

        string connectionString = "DefaultEndpointsProtocol=https;AccountName=mystorageaccount;AccountKey={your_key};EndpointSuffix=core.windows.net";
        string containerName = "site-blueprints";
        string localFilePath = "foundation_plan_v2.pdf";
        string blobName = "ProjectAlpha/foundation_plan_v2.pdf";

        try
        {
            // 1. Connect to the storage account
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // 2. Get a reference to the specific folder (container)
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            // 3. Get a reference to the specific file we want to create
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // 4. Upload the file to the cloud
            Console.WriteLine($"Uploading {localFilePath} to Azure...");
            using FileStream uploadFileStream = File.OpenRead(localFilePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            
            Console.WriteLine("Upload completely successfully. File is now secured in the cloud.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Upload failed: {ex.Message}");
        }
    }
}