using Geld.Core.Entities;
using Geld.Core.Infrastructure;
using Geld.Core.Repositories.Abstract;

namespace Geld.Core.Repositories
{
    public class PaymentRepository : EntityBaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(GeldDbContext context) : base(context)
        {
        }
    }
}
