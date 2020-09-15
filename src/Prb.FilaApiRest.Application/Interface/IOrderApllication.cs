using Prb.FilaApiRest.ApiModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prb.FilaApiRest.Application.Interface
{
    public interface IOrderApllication
    {
        Task<OrderViewModel.Response> InsertOrder(OrderViewModel.Request response);
    }
}
