using Geld.Core.Entities;
using Geld.Core.Infrastructure;
using Geld.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Geld.Core.Repositories
{
    public class PaymentRepository : EntityBaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(GeldDbContext context) : base(context)
        {
        }

        public IEnumerable<Payment> GetPaymentsByBilling(int billingId)
        {
            return _context.Payments.Where(x => x.Billing.Id == billingId)
                .Include(x => x.Billing);
        }
    }
}
