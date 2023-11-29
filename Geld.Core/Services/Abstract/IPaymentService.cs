using Geld.Core.Entities;
using Geld.Core.Repositories.Abstract;

namespace Geld.Core.Services.Abstract
{
    public interface IPaymentService
    {
        public ICollection<Payment> GetPaymentHistory(int billingId);

        public Payment GetPayment(int paymentId);
        public Payment DoPayment(int billingId, Decimal value);
    }
}
