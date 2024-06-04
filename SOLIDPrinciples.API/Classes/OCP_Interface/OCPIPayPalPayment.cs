namespace SOLIDPrinciples.API.Classes.OCP_Interface
{
    public class OCPIPayPalPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            // PayPal payment logic
            Console.WriteLine("Paying with PayPal, amount: " + amount);
        }
    }
}