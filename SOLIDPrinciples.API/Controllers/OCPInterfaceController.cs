using Microsoft.AspNetCore.Mvc;

using SOLIDPrinciples.API.Classes.OCP_Interface;

[ApiController]
[Route("api/[controller]")]
public class OCPInterfaceController : ControllerBase
{
    [HttpPost("process/creditcard")]
    public IActionResult CreditCard([FromBody] OCPIInterfacePaymentRequest request)
    {
        IPaymentMethod paymentMethod = new OCPICreditCardPayment();
        PaymentProcessor(paymentMethod, request.Amount);
        return Ok("Credit card payment processed successfully.");
    }

    [HttpPost("process/paypal")]
    public IActionResult PayPal([FromBody] OCPIInterfacePaymentRequest request)
    {
        IPaymentMethod paymentMethod = new OCPIPayPalPayment();
        PaymentProcessor(paymentMethod, request.Amount);
        return Ok("PayPal payment processed successfully.");
    }

    private void PaymentProcessor(IPaymentMethod paymentMethod, decimal amount)
    {
        paymentMethod.Pay(amount);
    }
}