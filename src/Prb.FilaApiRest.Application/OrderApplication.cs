using AutoMapper;
using Prb.FilaApiRest.ApiModel;
using Prb.FilaApiRest.Application.Interface;
using Prb.FilaApiRest.Domain;
using Prb.FilaApiRest.Domain.Service.Interface;
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

        public async Task<OrderViewModel.Response> InsertWithMassTransit(OrderViewModel.Request request)
        {
            var order = _mapper.Map<Order>(request);
            var orderService = await _orderService.InsertWithMassTransit(order);
            var response = _mapper.Map<OrderViewModel.Response>(orderService);
            return response; ;
        }
    }
}
