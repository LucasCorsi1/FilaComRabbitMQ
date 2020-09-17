using AutoMapper;
using Prb.FilaApiRest.ApiModel;
using Prb.FilaApiRest.Application.Interface;
using Prb.FilaApiRest.Domain;
using Prb.FilaApiRest.Domain.Service.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Application
{
    public class OrderApplication : IOrderApllication
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderApplication(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }
        public async Task<OrderViewModel.Response> InsertOrder(OrderViewModel.Request request, CancellationToken cancellationToken = default)
        {
            var order = _mapper.Map<Order>(request);
            var orderService = await _orderService.InsertOrder(order,cancellationToken);
            var response = _mapper.Map<OrderViewModel.Response>(orderService);
            return response;
        }
    }
}
