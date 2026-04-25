using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.AzureAppServices;

// When deploying a C# API to an Azure App Service, you often need to configure 
// the application to understand it is running behind Azure's load balancers.

var builder = WebApplication.CreateBuilder(args);

// 1. Configure Azure App Service Logging
// This allows you to view live application logs directly in the Azure Portal
builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "azure-diagnostics-";
    options.FileSizeLimit = 50 * 1024;
    options.RetainedFileCountLimit = 5;
});

var app = builder.Build();

// 2. Configure Forwarded Headers
// Azure App Services intercept web traffic and forward it to your app. 
// This middleware ensures your app reads the correct original IP address of the user.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.MapGet("/", () => "Hello from Azure App Service!");

app.Run();