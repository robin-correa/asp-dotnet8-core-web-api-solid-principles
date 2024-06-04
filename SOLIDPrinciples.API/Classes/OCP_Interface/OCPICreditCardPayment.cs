namespace SOLIDPrinciples.API.Classes.OCP_Interface
{
    public class OCPICreditCardPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            // Credit card payment logic
            Console.WriteLine("Paying with credit card, amount: " + amount);
        }
    }
}