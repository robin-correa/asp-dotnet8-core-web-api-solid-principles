
namespace SOLIDPrinciples.API.Classes.SRP
{
    public class PaymentLogger
    {
        public void Log(decimal amount)
        {
            Console.WriteLine("[SRP] PaymentLogger.Log() triggered.");
        }
    }
}