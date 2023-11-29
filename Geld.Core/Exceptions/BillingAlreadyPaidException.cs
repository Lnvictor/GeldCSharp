namespace Geld.Core.Exceptions
{
    public class BillingAlreadyPaidException : Exception
    {
        public BillingAlreadyPaidException(string message) : base(message) { }
    }
}
