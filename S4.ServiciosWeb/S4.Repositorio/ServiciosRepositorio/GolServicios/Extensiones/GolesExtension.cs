namespace S4.Repositorio.ServiciosRepositorio.GolServicios.Extensiones;

public static class GolesExtension
{

    public static IServiceCollection addGolExtension(this IServiceCollection services)
    {
        services.AddTransient<IGolRepositorio, GolRepositorio>();
        services.AddTransient<IGolDAC, GolDAC>();
        return services;
    }
}
