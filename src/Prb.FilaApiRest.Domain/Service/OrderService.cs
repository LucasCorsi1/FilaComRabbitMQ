using Prb.FilaApiRest.Domain.Rabbit.Interfaces;
using Prb.FilaApiRest.Domain.Service.Interface;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Domain.Service
{
    public class OrderService : IOrderService
    {
        private IRabbitManager _manager;

        public OrderService(IRabbitManager rabbitManager)
        {
            _manager = rabbitManager;
        }

        public async Task<Order> InsertOrder(Order order, CancellationToken cancellationToken = default)
        {
            _manager.Publish(order, "teste", "fanout", "OrderQueue");
            return order;
        }
    }
}
