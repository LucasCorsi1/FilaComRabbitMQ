using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prb.FilaApiRest.Domain.AzureServiceBus;
using Prb.FilaApiRest.Domain.RabbitMQ;
using Prb.FilaApiRest.Domain.Service;
using RabbitMQ.Client;
using System;

namespace Prb.FilaApiRest.Domain
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();
            services.ConfigureMassTransitRabbit();
            return services;
        }

        private static void ConfigureMassTransitRabbit(this IServiceCollection services)
        {
            services.AddMassTransit<IAzureServiceBusService>(x =>
            {
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host("Endpoint=sb://prbbabysharks.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=HvNm7m+t5ZTFO0gFQZx/0qfw4qJtMmEzzNIo6HgLXPc=");
                    cfg.ReceiveEndpoint("teste", e =>
                    {
                        e.PrefetchCount = 100;
                        e.MaxConcurrentCalls = 100;
                        e.LockDuration = TimeSpan.FromMinutes(5);
                        e.MaxAutoRenewDuration = TimeSpan.FromMinutes(30);
                    });
                });
            });

            services.AddMassTransit<IRabitMqService>(x => {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("Prb.FilaApiRest.Domain:Order", e =>
                    {
                    });
                });
            });

            services.AddMassTransitHostedService();
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
