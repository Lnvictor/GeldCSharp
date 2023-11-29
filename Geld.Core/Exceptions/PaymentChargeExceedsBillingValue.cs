using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geld.Core.Exceptions
{
    public class PaymentValueExceedsBillingValueException : Exception
    {
        public PaymentValueExceedsBillingValueException(string message): base(message) { }
    }
}
