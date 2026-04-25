using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace FinalIntegrations
{
    // 296. Generate PDF Reports (iText7).
    // Essential for generating legal compliance documents and 
    // safety certificates that cannot be edited.

    public class PdfService
    {
        public void CreateSafetyCertificate(string dest, string workerName)
        {
            using PdfWriter writer = new(dest);
            using PdfDocument pdf = new(writer);
            Document document = new(pdf);
            document.Add(new Paragraph("Safety Compliance Certificate"));
            document.Add(new Paragraph($"Certified Worker: {workerName}"));
        }
    }
}