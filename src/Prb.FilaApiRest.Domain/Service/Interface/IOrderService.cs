using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Domain.Service.Interface
{
    public interface IOrderService
    {
        Task<Order> InsertOrder(Order order, CancellationToken cancellationToken = default);
    }
}
