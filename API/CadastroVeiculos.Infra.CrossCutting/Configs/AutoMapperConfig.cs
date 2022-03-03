using AutoMapper;
using CadastroVeiculos.Infra.CrossCutting.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroVeiculos.Infra.CrossCutting.Configs
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection ConfigurarAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<VeiculoProfile>();
                mc.AddProfile<ProprietarioProfile>();
            });

            services.AddSingleton(mappingConfig.CreateMapper());

            return services;
        }
    }
}
