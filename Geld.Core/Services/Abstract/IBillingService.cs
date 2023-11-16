using Geld.Core.Entities;

namespace Geld.Core.Services.Abstract
{
    public interface IBillingService
    {
        MonthlyBilling GetBillingById(int id);
        List<MonthlyBilling> GetBillingsByYear(int year);
        ICollection<MonthlyBilling> UpdateMonthlyBillings(Order order);
    }
}
