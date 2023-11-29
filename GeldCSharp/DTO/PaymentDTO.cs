using Geld.Core.Entities;

namespace GeldCSharp.DTO
{
    public class PaymentDTO
    {
        public int BillingId { get; set; }
        public Decimal Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public static PaymentDTO ToDTO(Payment payment)
        {
            return new PaymentDTO
            {
                BillingId = payment.Billing.Id,
                Value = payment.Value,
                CreatedAt = payment.CreatedAt,
                UpdatedAt = payment.UpdatedAt
            };
        }

        public static List<PaymentDTO> ToDTO(ICollection<Payment> payments)
        {
            List<PaymentDTO> paymentDTOs = new List<PaymentDTO>();

            foreach (Payment payment in payments)
            {
                paymentDTOs.Add(ToDTO(payment));
            }

            return paymentDTOs;
        }
    }
}
