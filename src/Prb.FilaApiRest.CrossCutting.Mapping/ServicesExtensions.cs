using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

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
