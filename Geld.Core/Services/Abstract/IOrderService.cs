using Geld.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geld.Core.Services.Abstract
{
    public interface IOrderService
    {
        Order Add([NotNull] Order order);
        Order Retrieve([NotNull] int id);
    }
}
