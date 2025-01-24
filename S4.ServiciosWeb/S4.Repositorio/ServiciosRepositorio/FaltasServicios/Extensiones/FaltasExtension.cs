namespace S4.Repositorio.ServiciosRepositorio.FaltasServicios.Extensiones;

public static class FaltasExtension
{
    public static IServiceCollection addFaltasExtension(this IServiceCollection services)
    {
        services.AddTransient<IFaltasRepositorio, FaltaRepositorio>();
        services.AddTransient<IFaltasDAC, FaltasDAC>();
        return services;
    }
}
