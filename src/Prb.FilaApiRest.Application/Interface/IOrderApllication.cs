using Prb.FilaApiRest.ApiModel;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Application.Interface
{
    public interface IOrderApllication
    {
        Task<OrderViewModel.Response> InsertWithMassTransit(OrderViewModel.Request order);
    }
}
