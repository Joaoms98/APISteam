using APISteam.Infra.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace APISteam.Infra.IoC;

public static class IoCWrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<FeaturedAndRecommendsFilter, FeaturedAndRecommendsFilter>();
    }

    public static void RegisterUseCases(IServiceCollection services)
    {
    }

    public static void ConfigureDomainServices(IServiceCollection services)
    {
    }

    public static void ConfigureAutoMapper(IServiceCollection services, params string[] assemblyNames)
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(assemblyNames);
        });

        configuration.AssertConfigurationIsValid();

        services.AddSingleton<IMapper>(configuration.CreateMapper());
    }
}
