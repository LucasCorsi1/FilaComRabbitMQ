using Microsoft.Azure.ServiceBus;
using Prb.FilaApiRest.Domain.Service.Interface;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Domain.Service
{
    public class OrderService : IOrderService
    {
        private readonly RabbitMQ _rabbitMQ = new RabbitMQ();

        public async Task<Order> InsertOrder(Order order, CancellationToken cancellationToken = default)
        {
            string message =  JsonSerializer.Serialize(order);
            await _rabbitMQ.SendToQueue(message,cancellationToken);
            return order;
        }
    }
}
