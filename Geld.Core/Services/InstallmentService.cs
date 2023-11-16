using Geld.Core.Entities;
using Geld.Core.Repositories.Abstract;
using Geld.Core.Services.Abstract;

namespace Geld.Core.Services
{
    public class InstallmentService : IInstallmentService
    {
        private readonly IInstallmentRepository _repository;

        public InstallmentService(IInstallmentRepository repository)
        {
            _repository = repository;
        }

        public List<Installment> CreateInstallmentsForOrder(Order order, ICollection<MonthlyBilling> billings)
        {
            decimal installmentValue = order.Value / order.InstallmentsNumber;
            List<Installment> installments = new List<Installment>();

            foreach (var billing in billings)
            {
                Installment installment = new Installment();
                installment.Value = installmentValue;
                installment.Order = order;
                installment.Billing = billing;
                _repository.Add(installment);
                installments.Add(installment);
            }
            _repository.Commit();
            return installments;
        }

        public List<Installment> GetInstallmentsByBillings(int id)
        {
            var Installments = _repository.FindBy(x => x.Billing.Id == id);
            return Installments.ToList();
        }
    }
}
