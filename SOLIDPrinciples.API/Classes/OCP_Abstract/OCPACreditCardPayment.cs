namespace SOLIDPrinciples.API.Classes.OCP_Abstract
{
    public class OCPACreditCardPayment : PaymentMethodAbstract
    {
        public override void Pay(decimal amount)
        {
            // Credit card payment logic
            Console.WriteLine("Paying with credit card, amount: " + amount);
        }
    }
}
