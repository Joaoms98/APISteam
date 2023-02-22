using APISteam.Infra.IoC;
using APISteam.Web.Filters;

namespace APISteam.Web.Configurations;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        IoCWrapper.RegisterServices(services);
        services.AddScoped<ExceptionFilter, ExceptionFilter>();
        
        return services;
    }
}