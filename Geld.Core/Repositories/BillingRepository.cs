using Geld.Core.Entities;
using Geld.Core.Infrastructure;
using Geld.Core.Repositories.Abstract;

namespace Geld.Core.Repositories
{
    public class BillingRepository : EntityBaseRepository<MonthlyBilling>, IBillingRepository
    {
        public BillingRepository(GeldDbContext context) : base(context)
        {
        }
    }
}
