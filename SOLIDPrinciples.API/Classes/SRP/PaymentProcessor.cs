
namespace SOLIDPrinciples.API.Classes.SRP
{
    public class PaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("[SRP] PaymentProcessor.ProcessPayment() triggered.");
        }
    }
}