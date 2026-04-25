using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace FinalIntegrations
{
    // 298. Twilio SMS Integration.
    // Sends urgent safety alerts directly to workers' phones via SMS.

    public class SmsService
    {
        public void SendUrgentSms(string mobileNumber, string alert)
        {
            TwilioClient.Init("ACCOUNT_SID", "AUTH_TOKEN");
            MessageResource.Create(
                body: $"URGENT: {alert}",
                from: new Twilio.Types.PhoneNumber("+1234567890"),
                to: new Twilio.Types.PhoneNumber(mobileNumber)
            );
        }
    }
}