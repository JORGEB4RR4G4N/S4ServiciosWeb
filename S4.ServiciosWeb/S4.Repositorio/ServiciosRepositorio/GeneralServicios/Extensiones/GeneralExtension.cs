namespace S4.Repositorio.ServiciosRepositorio.GeneralServicios.Extensiones;

public static class GeneralExtension
{
    public static IServiceCollection addGeneralExtension(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddTransient<ITorneoRepositorio, TorneoRepositorio>();
        serviceProvider.AddTransient<ITorneoDAC, TorneoDAC>();

        serviceProvider.AddTransient<ITablaGeneralRepositorio, TablaGeneralRepositorio>();
        serviceProvider.AddTransient<ITablaGeneralDAC, TablaGeneralDAC>();

        serviceProvider.AddTransient<IPartidoRepositorio, PartidoRepositorio>();
        serviceProvider.AddTransient<IPartidoDAC, PartidoDAC>();

        return serviceProvider;
    }
}
