using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Geld.Core.Entities;

namespace GeldCSharp.DTO
{
    public class BillingDTO
    {
        public Decimal TotalValue { get; set; }
        public bool IsPaid { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public static BillingDTO ToDTO(MonthlyBilling billing)
        {
            return new BillingDTO
            {
                TotalValue = billing.TotalValue,
                IsPaid = billing.IsPaid,
                Month = billing.Month,
                Year = billing.Year,
                Expiration = billing.Expiration,
                CreatedAt = billing.CreatedAt,
                UpdatedAt = billing.UpdatedAt
            };
        }

        public static List<BillingDTO> ToDTO(ICollection<MonthlyBilling> billings) 
        { 
            List<BillingDTO > result = new List<BillingDTO>();

            foreach (var billing in billings)
            {
                result.Add(ToDTO(billing));
            }

            return result;
        }
    }
}
