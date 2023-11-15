using Geld.Core.Entities;
using Geld.Core.Repositories.Abstract;
using Geld.Core.Services.Abstract;

namespace Geld.Core.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _repository;
        public ICollection<MonthlyBilling> UpdateMonthlyBillings(Order order)
        {
            int creationDay = order.CreatedAt.Day;
            int creationMonth = order.CreatedAt.Month;
            int creationYear = order.CreatedAt.Year;


            //TODO: Implements logic
            return new List<MonthlyBilling>();
        }
    }
}
