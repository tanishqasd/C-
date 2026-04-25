using Stripe;

namespace FinalIntegrations
{
    // 299. Stripe Payment Gateway Integration.
    // Handles vendor payments and site subscriptions securely.

    public class PaymentService
    {
        public void ProcessVendorPayment(long amountInCents)
        {
            StripeConfiguration.ApiKey = "sk_test_...";
            var options = new PaymentIntentCreateOptions
            {
                Amount = amountInCents,
                Currency = "inr",
                PaymentMethodTypes = new List<string> { "card" },
            };
            var service = new PaymentIntentService();
            service.Create(options);
        }
    }
}