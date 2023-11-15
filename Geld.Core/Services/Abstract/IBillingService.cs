using Geld.Core.Entities;

namespace Geld.Core.Services.Abstract
{
    public interface IBillingService
    {
        ICollection<MonthlyBilling> UpdateMonthlyBillings(Order order);
    }
}
