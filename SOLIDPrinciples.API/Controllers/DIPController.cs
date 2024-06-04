using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DIPController : ControllerBase
{
    private readonly IPaymentGateway _paymentGateway;

    public DIPController(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    [HttpPost("process")]
    public IActionResult ProcessPayment([FromBody] PaymentRequest request)
    {
        _paymentGateway.ProcessPayment(request.Amount);
        return Ok("Payment processed successfully.");
    }
}

// Supporting interfaces and classes for DIP

public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

public interface IPaymentGateway2
{
    void ProcessPayment(decimal amount);
}

public class StripePaymentGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        // Stripe payment processing logic
        Console.WriteLine("Processing payment through Stripe, amount: " + amount);
    }
}

public class PayPalPaymentGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        // PayPal payment processing logic
        Console.WriteLine("Processing payment through PayPal, amount: " + amount);
    }
}

public class PaymentRequest
{
    public decimal Amount { get; set; }
}
