using Prb.FilaApiRest.Domain.AzureServiceBus;
using Prb.FilaApiRest.Domain.RabbitMQ;
using Prb.FilaApiRest.Domain.Service.Interface;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Domain.Service
{
    public class OrderService : IOrderService
    {
        private readonly IAzureServiceBusService _azureServiceBus;
        private readonly IRabitMqService _rabitMq;

        public OrderService( IAzureServiceBusService azureServiceBus, IRabitMqService rabitMq)
        {
            _azureServiceBus = azureServiceBus;
            _rabitMq = rabitMq;
        }

        public async Task<Order> InsertWithMassTransit(Order order)
        {
            await _azureServiceBus.Publish(order);
            await _rabitMq.Publish(order);
            return order;
        }
    }
}
