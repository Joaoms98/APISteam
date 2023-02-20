using APISteam.Infra.IoC;

namespace APISteam.Web.Configurations;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        IoCWrapper.RegisterServices(services);
        return services;
    }
}