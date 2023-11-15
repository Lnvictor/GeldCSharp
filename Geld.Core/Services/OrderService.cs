
using Geld.Core.Entities;
using Geld.Core.Repositories.Abstract;
using Geld.Core.Services.Abstract;
using System.Diagnostics.CodeAnalysis;

namespace Geld.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Order Add([NotNull] Order order)
        {
            _repository.Add(order);
            _repository.Commit();
            return order;
        }

        public Order Retrieve([NotNull] int id)
        {
            return _repository.GetSingle(id);
        }
    }
}
