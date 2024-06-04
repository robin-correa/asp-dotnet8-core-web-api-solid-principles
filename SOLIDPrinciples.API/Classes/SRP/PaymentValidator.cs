
namespace SOLIDPrinciples.API.Classes.SRP
{
    public class PaymentValidator
    {
        public bool Validate(decimal amount)
        {
            Console.WriteLine("[SRP] PaymentValidator.Validate() triggered.");
            return true;
        }
    }
}