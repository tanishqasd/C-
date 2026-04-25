using OfficeOpenXml; // Requires EPPlus NuGet
using System.IO;

namespace FinalIntegrations
{
    // 295. Export to Excel (EPPlus).
    // Site Managers love Excel. This program generates professional 
    // material audit reports directly from your C# data objects.

    public class ExcelGenerator
    {
        public byte[] GenerateMaterialReport(IEnumerable<dynamic> data)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Inventory");
            worksheet.Cells["A1"].Value = "Material Name";
            worksheet.Cells["B1"].Value = "Quantity";
            
            // Fill data...
            return package.GetAsByteArray();
        }
    }
}