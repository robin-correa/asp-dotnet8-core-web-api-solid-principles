namespace SOLIDPrinciples.API.Classes.OCP_Interface
{
    public interface IPaymentMethod
    {
        void Pay(decimal amount);
    }
}