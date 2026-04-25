using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace FinalIntegrations
{
    // 300. Multi-Language Support (Localization).
    // The final piece! Your system can now serve workers in Marathi, 
    // Hindi, or English by switching language files based on the browser settings.

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            var app = builder.Build();

            var supportedCultures = new[] { "en-US", "hi-IN", "mr-IN" };
            app.UseRequestLocalization(new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures));
            
            // app.Run();
        }
    }
}