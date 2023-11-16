namespace Geld.Core.Util
{
   public class DateTimeHelper
   {
        private const int NUMBER_OF_INSTALLMENTS_BY_YEAR = 12;
        public static List<int> GetNextMonth(int year, int month)
        {
            if (month == 12) {
                year++;
                month = 1;
            }
            else
            {
                month++;
            }

            return new List<int>
            {
                month,
                year
            };
        }

        public static List<int> GetFinalMonthAndYear(int creationMonth, int creationYear, int numberOfInstallments)
        {
            int month;
            int year;
            List <int> ints = new List<int>();

            if (creationMonth + numberOfInstallments > NUMBER_OF_INSTALLMENTS_BY_YEAR)
            {
                month = creationMonth + numberOfInstallments - NUMBER_OF_INSTALLMENTS_BY_YEAR;
                year = creationYear + 1;
            }
            else
            {
                month = creationMonth + numberOfInstallments;
                year = creationYear;
            }

            return new List<int> {month, year};
        }
    }
}
