using Geld.Core.Entities;
using Geld.Core.Infrastructure;
using Geld.Core.Repositories.Abstract;

namespace Geld.Core.Repositories
{
    public class InstallmentRepository : EntityBaseRepository<Installment>, IInstallmentRepository
    {
        public InstallmentRepository(GeldDbContext context) : base(context)
        {
        }
    }
}
