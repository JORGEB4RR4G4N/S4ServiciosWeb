

namespace S4.Repositorio.ServiciosRepositorio.CambiosServicios.Extensiones;

public static class CambiosExtension 
{
    public static IServiceCollection addCambioExtension(this IServiceCollection services)
    {
        services.AddTransient<ICambiosRepositorio, CambiosRepositorio>();
        services.AddTransient<ICambioDAC, CambioDAC>();
        return services;
    }
}
