using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Prb.FilaApiRest.Application
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();

            return services;
        }


        private static void RegisterServices(this IServiceCollection services)
        {
            services.Scan(_ => _
           .FromAssemblies(
               typeof(OrderApplication).Assembly
           )
           .AddClasses()
           .AsImplementedInterfaces());
        }
    }
}
