namespace S4.Repositorio.ServiciosRepositorio.JugadoresServicios.Extensiones;
public static class JugadoresExtension
{
    public static IServiceCollection addJugadoresExtension(this IServiceCollection services)
    {
        services.AddTransient<IJugadoresRepositorio, JugadoresRepositorio>();
        services.AddTransient<IJugadorDAC, JugadorDAC>();
        return services;
    }
}
