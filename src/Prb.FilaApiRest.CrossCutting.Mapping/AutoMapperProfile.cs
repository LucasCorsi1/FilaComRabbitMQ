using AutoMapper;
using Prb.FilaApiRest.ApiModel;
using Prb.FilaApiRest.Domain;
using System;

namespace Prb.FilaApiRest.CrossCutting.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderViewModel.Request, Order>();
            CreateMap<Order, OrderViewModel.Response>();
        }
    }
}
