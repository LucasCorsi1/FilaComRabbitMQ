using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prb.FilaApiRest.Domain.Service;

namespace Prb.FilaApiRest.Domain
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();

            return services;
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
