using APISteam.Infra.IoC;

namespace APISteam.Web.Configurations;

public static class ConfigureAutoMapper
{
    public static IServiceCollection AddAutoMapperSettings(this IServiceCollection services, params string[] assemblyNames)
    {
        IoCWrapper.ConfigureAutoMapper(services, assemblyNames);
        return services;
    }
}
