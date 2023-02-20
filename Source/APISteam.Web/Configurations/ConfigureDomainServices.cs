using APISteam.Infra.IoC;

namespace APISteam.Web.Configurations;

public static class ConfigureDomainServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        IoCWrapper.RegisterUseCases(services);
        return services;
    }
}