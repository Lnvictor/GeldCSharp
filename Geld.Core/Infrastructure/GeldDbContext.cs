using Geld.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Geld.Core.Infrastructure
{
    public class GeldDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<MonthlyBilling> Billings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public GeldDbContext() { }

        public GeldDbContext(DbContextOptions<GeldDbContext> options) : base(options) { }
    }
}
