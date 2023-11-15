using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Geld.Core.Entities
{
    public class MonthlyBilling: IEntityBase
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Decimal TotalValue { get; set; }
        public bool IsPaid { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
