using Prb.FilaApiRest.ApiModel;
using System.Threading;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Application.Interface
{
    public interface IOrderApllication
    {
        Task<OrderViewModel.Response> InsertOrder(OrderViewModel.Request response, CancellationToken cancellationToken = default);
    }
}
