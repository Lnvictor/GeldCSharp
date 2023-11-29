using Geld.Core.Entities;
using Geld.Core.Infrastructure;
using Geld.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Geld.Core.Repositories
{
    public class InstallmentRepository : EntityBaseRepository<Installment>, IInstallmentRepository
    {
        public InstallmentRepository(GeldDbContext context) : base(context)
        {
        }

        public IEnumerable<Installment> FindByBilling(int billingId)
        {
            return _context.Installments.Where(x => x.Billing.Id == billingId)
                .Include(x => x.Billing).Include(x => x.Order);

        }
    }
}
