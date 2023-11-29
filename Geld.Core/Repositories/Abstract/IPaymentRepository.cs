using Geld.Core.Entities;

namespace Geld.Core.Repositories.Abstract
{
    public interface IPaymentRepository : IEntityBaseRepository<Payment>
    {

        public IEnumerable<Payment> GetPaymentsByBilling(int billingId);
    }
}
