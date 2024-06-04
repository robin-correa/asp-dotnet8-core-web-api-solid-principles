using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LSPController : ControllerBase
{
    [HttpPost("process/creditcard")]
    public IActionResult ProcessCreditCardPayment([FromBody] LSPPaymentRequest request)
    {
        PaymentMethod paymentMethod = new CreditCardPayment(); // Can be changed with PayPalPayment() and application will still not break
        ProcessPayment(paymentMethod, request.Amount);
        return Ok("Credit card payment processed successfully.");
    }

    [HttpPost("process/paypal")]
    public IActionResult ProcessPayPalPayment([FromBody] PaymentRequest request)
    {
        PaymentMethod paymentMethod = new PayPalPayment(); // Can be changed with CreditCardPayment() and application will still not break
        ProcessPayment(paymentMethod, request.Amount);
        return Ok("PayPal payment processed successfully.");
    }

    private void ProcessPayment(PaymentMethod paymentMethod, decimal amount)
    {
        paymentMethod.Pay(amount);
    }
}

// Supporting classes for LSP

public abstract class PaymentMethod
{
    public abstract void Pay(decimal amount);
}

public class CreditCardPayment : PaymentMethod
{
    public override void Pay(decimal amount)
    {
        // Credit card payment logic
        Console.WriteLine("Paying with credit card, amount: " + amount);
    }
}

public class PayPalPayment : PaymentMethod
{
    public override void Pay(decimal amount)
    {
        // PayPal payment logic
        Console.WriteLine("Paying with PayPal, amount: " + amount);
    }
}

public class LSPPaymentRequest
{
    public decimal Amount { get; set; }
}