using Geld.Core.Entities;

namespace Geld.Core.Repositories.Abstract
{
    public interface IInstallmentRepository : IEntityBaseRepository<Installment>
    { 
        public IEnumerable<Installment> FindByBilling(int billingId);
    }
}
