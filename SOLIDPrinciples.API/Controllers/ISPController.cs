using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ISPController : ControllerBase
{
    [HttpPost("process/creditcard")]
    public IActionResult ProcessCreditCardPayment([FromBody] ISPPaymentRequest request)
    {
        IPaymentProcessor paymentProcessor = new CreditCardProcessor();
        paymentProcessor.ProcessPayment(request.Amount);
        return Ok("Credit card payment processed successfully.");
    }

    [HttpPost("refund/creditcard")]
    public IActionResult RefundCreditCardPayment([FromBody] ISPPaymentRequest request)
    {
        IRefundProcessor refundProcessor = new CreditCardProcessor();
        refundProcessor.ProcessRefund(request.Amount);
        return Ok("Credit card refund processed successfully.");
    }

    [HttpPost("process/paypal")]
    public IActionResult ProcessPayPalPayment([FromBody] ISPPaymentRequest request)
    {
        IPaymentProcessor paymentProcessor = new PayPalProcessor();
        paymentProcessor.ProcessPayment(request.Amount);
        return Ok("PayPal payment processed successfully.");
    }
}

// Supporting interfaces and classes for ISP

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public interface IRefundProcessor
{
    void ProcessRefund(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor, IRefundProcessor
{
    public void ProcessPayment(decimal amount)
    {
        // Credit card payment logic
        Console.WriteLine("Processing credit card payment, amount: " + amount);
    }

    public void ProcessRefund(decimal amount)
    {
        // Credit card refund logic
        Console.WriteLine("Processing credit card refund, amount: " + amount);
    }
}

public class PayPalProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        // PayPal payment logic
        Console.WriteLine("Processing PayPal payment, amount: " + amount);
    }
}

public class ISPPaymentRequest
{
    public decimal Amount { get; set; }
}