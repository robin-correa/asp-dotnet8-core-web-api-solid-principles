namespace SOLIDPrinciples.API.Classes.OCP_Abstract
{
    public class OCPAPayPalPayment : PaymentMethodAbstract
    {
        public override void Pay(decimal amount)
        {
            // PayPal payment logic
            Console.WriteLine("Paying with PayPal, amount: " + amount);
        }
    }
}
