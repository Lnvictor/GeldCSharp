using Geld.Core.Entities;
using Geld.Core.Exceptions;
using Geld.Core.Repositories.Abstract;
using Geld.Core.Services.Abstract;
using Microsoft.Extensions.Logging;

namespace Geld.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IBillingRepository _billingRepository;

        private readonly ILogger _logger;

        public PaymentService(IPaymentRepository paymentRepository, IBillingRepository billingRepository, ILogger<PaymentService> logger)
        {
            _paymentRepository = paymentRepository;
            _billingRepository = billingRepository;
            _logger = logger;
        }

        public Payment DoPayment(int billingId, decimal value)
        {
            MonthlyBilling billing = _billingRepository.GetSingle(billingId);

            if (billing.IsPaid)
            {
                _logger.LogError($"Billing Already paid |Payment value: {value} | BillingId: {billingId}");
                throw new BillingAlreadyPaidException("This billing was totally paid");
            }

            IEnumerable<Payment> paymentsAlreadyDone = _paymentRepository.FindBy(x => x.Billing.Id ==  billingId);
            Decimal valuePaid = value;

            foreach (Payment p in paymentsAlreadyDone)
            {
                valuePaid += p.Value;
            }

            if (valuePaid > billing.TotalValue)
            {
                _logger.LogError($"Value Exceeds billing value | Payment value: {value} | BillingId: {billingId}");
                throw new PaymentValueExceedsBillingValueException($"Payment value: {value} exceeds the billing value");
            }

            if (billing.TotalValue.Equals(valuePaid))
            {
                billing.IsPaid = true;
            }

            Payment payment = new Payment();
            payment.Value = value;
            payment.Billing = billing;
            _paymentRepository.Add(payment);

            _billingRepository.Commit();
            _paymentRepository.Commit();
            return payment;
        }

        public Payment GetPayment(int paymentId)
        {
            return _paymentRepository.GetSingle(paymentId);
        }

        public ICollection<Payment> GetPaymentHistory(int billingId)
        {
            var paymentHistory = _paymentRepository.GetPaymentsByBilling(billingId);

            return paymentHistory.ToList();
        }
    }
}
