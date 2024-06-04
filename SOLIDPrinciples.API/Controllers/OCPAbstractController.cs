using Microsoft.AspNetCore.Mvc;

using SOLIDPrinciples.API.Classes.OCP_Abstract;

[ApiController]
[Route("api/[controller]")]
public class OCPAbstractController : ControllerBase
{
    [HttpPost("process/creditcard")]
    public IActionResult CreditCard([FromBody] OCPAPaymentRequest request)
    {
        var paymentMethod = new OCPACreditCardPayment();
        PaymentProcessor(paymentMethod, request.Amount);
        return Ok("Credit card payment processed successfully.");
    }

    [HttpPost("process/paypal")]
    public IActionResult PayPal([FromBody] OCPAPaymentRequest request)
    {
        var paymentMethod = new OCPAPayPalPayment();
        PaymentProcessor(paymentMethod, request.Amount);
        return Ok("PayPal payment processed successfully.");
    }

    private void PaymentProcessor(PaymentMethodAbstract paymentMethod, decimal amount)
    {
        paymentMethod.Pay(amount);
    }
}