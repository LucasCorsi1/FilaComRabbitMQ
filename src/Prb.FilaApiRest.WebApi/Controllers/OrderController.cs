using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prb.FilaApiRest.ApiModel;
using Prb.FilaApiRest.Application.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.WebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderApllication _orderApllication;

        public OrderController(ILogger<OrderController> logger , IOrderApllication orderApllication)
        {
            _logger = logger;
            _orderApllication = orderApllication;
        }

        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> InsertOrder(OrderViewModel.Request order , CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _orderApllication.InsertOrder(order, cancellationToken);
                return Accepted(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao criar pedido", ex);

                return new StatusCodeResult(500);
            }
        }
    }
}
