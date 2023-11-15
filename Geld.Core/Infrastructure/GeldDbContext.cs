using Geld.Core.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = "Host=motty.db.elephantsql.com;Database=edpibvhc;Username=edpibvhc;Password=1f5CcGg35PKpQRUXsLQjPmdWs10KPRKn";
                optionsBuilder.UseNpgsql(connString);
            }
        }
    }
}
