using System;
using Moq; // Requires Moq NuGet package
using Xunit;

// 1. The Interface (Dependency)
public interface IPaymentGateway
{
    bool ProcessPayment(decimal amount);
}

// 2. The Class Being Tested
public class CheckoutService
{
    private readonly IPaymentGateway _paymentGateway;

    public CheckoutService(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public string CompleteCheckout(decimal total)
    {
        bool success = _paymentGateway.ProcessPayment(total);
        return success ? "Order Placed!" : "Payment Failed.";
    }
}

// 3. The Test using Moq
public class CheckoutServiceTests
{
    [Fact]
    public void CompleteCheckout_WhenPaymentSucceeds_ReturnsSuccessMessage()
    {
        // Arrange: Create a "Mock" (fake) version of the payment gateway
        var mockGateway = new Mock<IPaymentGateway>();
        
        // Setup the mock to ALWAYS return true when asked to process 100
        mockGateway.Setup(g => g.ProcessPayment(100m)).Returns(true);

        // Inject the fake gateway into our service
        var service = new CheckoutService(mockGateway.Object);

        // Act
        string result = service.CompleteCheckout(100m);

        // Assert
        Assert.Equal("Order Placed!", result);
        
        // Verify that the method was actually called exactly once
        mockGateway.Verify(g => g.ProcessPayment(100m), Times.Once);
    }
}