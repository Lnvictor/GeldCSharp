using Geld.Core.Entities;

namespace Geld.Core.Services.Abstract
{
    public interface IInstallmentService
    {
        public List<Installment> CreateInstallmentsForOrder(Order order, ICollection<MonthlyBilling> billings);
        List<Installment> GetInstallmentsByBillings(int id);
    }
}
