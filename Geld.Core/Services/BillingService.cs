using Geld.Core.Entities;
using Geld.Core.Repositories.Abstract;
using Geld.Core.Services.Abstract;
using Geld.Core.Util;

namespace Geld.Core.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _repository;

        public BillingService (IBillingRepository repository)
        {
            _repository = repository;
        }

        public MonthlyBilling GetBillingById(int id)
        {
            return _repository.GetSingle(x => x.Id == id);
        }

        public List<MonthlyBilling> GetBillingsByYear(int year)
        {
            var billings = _repository.FindBy(x => x.Year == year);
            return billings.ToList();
        }

        public ICollection<MonthlyBilling> UpdateMonthlyBillings(Order order)
        {
            List<MonthlyBilling> responseList = new List<MonthlyBilling>();
            int currentMonth = order.CreatedAt.Month;
            int currentYear = order.CreatedAt.Year;
            decimal value = order.Value / order.InstallmentsNumber;
            
            if (order.CreatedAt.Day > 3) {
                List<int> nextMonthInfo = DateTimeHelper.GetNextMonth(currentYear, currentMonth);                
                currentMonth = nextMonthInfo[0];
                currentYear = nextMonthInfo[1];
            }

            // Getting The first month/year when we won't need to pay it
            // index:
            // [0] -> month
            // [1] -> year
            List<int> finalInfo = DateTimeHelper.GetFinalMonthAndYear(currentMonth, currentYear, order.InstallmentsNumber);

            while (currentMonth != finalInfo[0] || currentYear != finalInfo[1])
            {
                MonthlyBilling billing = GetBillingForMonth(currentMonth, currentYear);

                if (billing is not null)
                {
                    decimal newValue = billing.TotalValue + value;
                    billing.TotalValue = newValue;
                    _repository.Update(billing);
                    responseList.Add(billing);
                }
                else
                {
                    responseList.Add(CreateBilling(currentMonth, currentYear, value));
                }

                List<int> nextMonth = DateTimeHelper.GetNextMonth(currentYear, currentMonth);
                currentMonth = nextMonth[0];
                currentYear = nextMonth[1];
            }

            _repository.Commit();
            return responseList;
        }

        private MonthlyBilling CreateBilling(int currentMonth, int currentYear, decimal value)
        {
            MonthlyBilling billing = new MonthlyBilling();
            billing.Month = currentMonth;
            billing.Year = currentYear;
            billing.TotalValue = value;
            billing.IsPaid = false;

            billing.Expiration = new DateTime(currentYear, currentMonth, 10);
            _repository.Add(billing);
            return billing;
        }

        private MonthlyBilling GetBillingForMonth(int currentMonth, int currentYear)
        {
            return _repository.GetSingle(x => x.Month == currentMonth && x.Year == currentYear);
        }
    }
}
