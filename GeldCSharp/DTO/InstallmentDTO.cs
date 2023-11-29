using Geld.Core.Entities;

namespace GeldCSharp.DTO
{
    public class InstallmentDTO
    {
        public int OrderId { get; set; }
        public int BillingId { get; set; }
        public Decimal Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public static InstallmentDTO ToDTO(Installment installment)
        {
            return new InstallmentDTO
            {
                OrderId = installment.Order.Id,
                BillingId = installment.Billing.Id,
                Value = installment.Value,
                CreatedAt = installment.CreatedAt,
                UpdatedAt = installment.UpdatedAt
            };
        }

        public static List<InstallmentDTO> ToDTO(ICollection<Installment> installments)
        {
            var dtos = new List<InstallmentDTO>();

            foreach (var installment in installments)
            {
                dtos.Add(ToDTO(installment));
            }

            return dtos;
        }
    }
}
