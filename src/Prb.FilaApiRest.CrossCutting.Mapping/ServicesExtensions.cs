using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.FilaApiRest.CrossCutting.Mapping
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper());

            return services;
        }
    }
}
