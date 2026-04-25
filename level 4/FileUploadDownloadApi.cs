using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Ensure an upload directory exists (e.g., for storing site blueprints or contracts)
string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
Directory.CreateDirectory(uploadPath);

// 1. UPLOAD ENDPOINT
app.MapPost("/api/files/upload", async (IFormFile file) =>
{
    if (file == null || file.Length == 0) return Results.BadRequest("No file uploaded.");

    string filePath = Path.Combine(uploadPath, file.FileName);
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await file.CopyToAsync(stream);
    }

    return Results.Ok(new { Message = "File uploaded successfully.", FileName = file.FileName });
});

// 2. DOWNLOAD ENDPOINT
app.MapGet("/api/files/download/{fileName}", (string fileName) =>
{
    string filePath = Path.Combine(uploadPath, fileName);
    if (!File.Exists(filePath)) return Results.NotFound("File not found.");

    // Return the file as an application stream
    return Results.File(filePath, "application/octet-stream", fileName);
});

app.Run();