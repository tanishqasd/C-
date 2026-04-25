using SendGrid;
using SendGrid.Helpers.Mail;

namespace FinalIntegrations
{
    // 297. SendGrid Email Integration.
    // Automatically sends daily site summaries or password reset emails.

    public class EmailService
    {
        public async Task SendAlertEmail(string email, string subject, string content)
        {
            var client = new SendGridClient("YOUR_SENDGRID_KEY");
            var from = new EmailAddress("alerts@construction-corp.com", "Site System");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            await client.SendEmailAsync(msg);
        }
    }
}