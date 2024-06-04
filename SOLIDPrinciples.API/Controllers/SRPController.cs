using Microsoft.AspNetCore.Mvc;

using SOLIDPrinciples.API.Classes.SRP;

namespace SOLIDPrinciples.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRPController : ControllerBase
    {
        private readonly PaymentProcessor _paymentProcessor;
        private readonly PaymentValidator _paymentValidator;
        private readonly PaymentLogger _paymentLogger;
        public SRPController()
        {
            _paymentProcessor = new PaymentProcessor();
            _paymentValidator = new PaymentValidator();
            _paymentLogger = new PaymentLogger();
        }

        [HttpPost("process")]
        public IActionResult ProcessPayment([FromBody] decimal amount)
        {
            if (!_paymentValidator.Validate(amount))
            {
                return BadRequest("Invalid payment amount.");
            }

            _paymentProcessor.ProcessPayment(amount);
            _paymentLogger.Log(amount);

            return Ok("Payment processed successfully.");
        }
    }
}
