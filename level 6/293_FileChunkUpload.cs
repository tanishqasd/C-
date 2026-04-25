using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FinalIntegrations
{
    // 293. File Chunk Upload API.
    // 3D Site Blueprints are massive. Uploading them in one go often fails. 
    // This API accepts "chunks" of a file and stitches them together on the server.

    [HttpPost("upload-chunk")]
    public async Task<IActionResult> UploadChunk(IFormFile chunk, int chunkIndex, string fileName)
    {
        var tempPath = Path.Combine("temp_uploads", fileName);
        using (var stream = new FileStream(tempPath, FileMode.Append))
        {
            await chunk.CopyToAsync(stream);
        }
        return Ok();
    }
}