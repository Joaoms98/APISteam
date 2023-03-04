using APISteam.Domain.Interface;
using APISteam.Domain.UseCases;
using APISteam.Infra.Repositories;
using APISteam.Infra.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace APISteam.Infra.IoC;

public static class IoCWrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<FeaturedAndRecommendsFilter, FeaturedAndRecommendsFilter>();
    }

    public static void RegisterUseCases(IServiceCollection services)
    {
        services.AddScoped<ListAllGenresUseCase>();
        services.AddScoped<RegisterUserUseCase>();
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
