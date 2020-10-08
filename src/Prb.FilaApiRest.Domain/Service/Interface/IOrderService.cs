using System.Threading.Tasks;

namespace Prb.FilaApiRest.Domain.Service.Interface
{
    public interface IOrderService
    {
        Task<Order> InsertWithMassTransit(Order order);
    }
}
