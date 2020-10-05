using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;
using Prb.FilaApiRest.Domain.Rabbit;
using Prb.FilaApiRest.Domain.Rabbit.Interfaces;
using Prb.FilaApiRest.Domain.Service;
using RabbitMQ.Client;

namespace Prb.FilaApiRest.Domain
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();
            services.RegisterOptions(configuration);
            return services;
        }

        public static IServiceCollection AddRabbit(this IServiceCollection services)
        {
            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<IPooledObjectPolicy<IModel>, RabbitModel>();
            services.AddSingleton<IRabbitManager, RabbitManager>();

            return services;
        }

        private static void RegisterOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitOptions>(configuration.GetSection("rabbit"));
        }


        private static void RegisterServices(this IServiceCollection services)
        {
            services.Scan(_ => _
           .FromAssemblies(
               typeof(OrderService).Assembly
           )
           .AddClasses()
           .AsImplementedInterfaces());
        }
    }
}
