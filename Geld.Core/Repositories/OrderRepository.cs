using Geld.Core.Entities;
using Geld.Core.Infrastructure;
using Geld.Core.Repositories.Abstract;

namespace Geld.Core.Repositories
{
    public class OrderRepository : EntityBaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(GeldDbContext context) : base(context)
        {
        }
    }
}
