using Geld.Core.Entities;

namespace GeldCSharp.DTO
{
    public class OrderDTO
    { 
        public Decimal Value { get; set; }
        public int InstallmentsNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public static OrderDTO ToDTO(Order order)
        {
            return new OrderDTO
            {
                Value = order.Value,
                InstallmentsNumber = order.InstallmentsNumber,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt
            };
        }

        public static List<OrderDTO> ToDTO(ICollection<Order> orders)
        {
            var dtos = new List<OrderDTO>();
            foreach (var o in orders)
            {
                dtos.Add(ToDTO(o));
            }

            return dtos;
        }
    }
}
