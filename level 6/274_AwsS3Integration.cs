using Amazon.S3;
using Amazon.S3.Transfer;
using System.Threading.Tasks;

namespace CloudNative
{
    // 274. AWS S3 Bucket Integration.
    // Industry-standard cloud storage for large files like 
    // 3D site blueprints (BIM files) and drone survey videos.

    public class S3Uploader
    {
        private const string bucketName = "site-blueprints-storage";
        private static readonly AmazonS3Client s3Client = new();

        public async Task UploadFileAsync(string filePath, string keyName)
        {
            var fileTransferUtility = new TransferUtility(s3Client);
            await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
            Console.WriteLine($"[AWS S3] Uploaded {keyName} successfully.");
        }
    }
}