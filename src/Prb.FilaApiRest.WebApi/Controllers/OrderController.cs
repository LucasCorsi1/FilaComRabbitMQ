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
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderApllication _orderApllication;


        public OrderController(
            ILogger<OrderController> logger,
            IOrderApllication orderApllication)
        {
            _logger = logger;
            _orderApllication = orderApllication;
        }


        [HttpPost]
        [Route("/rabbitwithmasstransit")]
        public async Task<IActionResult> InsertOrderMassTransit(OrderViewModel.Request order, CancellationToken cancellationToken = default)
        {
            try
            {
                await _orderApllication.InsertWithMassTransit(order);
                return Ok("Ordem Aceita");
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao criar Ordem", ex);

                return new StatusCodeResult(500);
            }
        }
    }
}
