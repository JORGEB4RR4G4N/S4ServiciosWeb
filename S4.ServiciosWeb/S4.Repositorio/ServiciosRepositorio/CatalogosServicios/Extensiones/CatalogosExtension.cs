namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios.Extensiones;

public static class CatalogosExtension
{
    public static IServiceCollection addCatalogosExtension(this IServiceCollection services)
    {
        services.AddTransient<IOrigenRepositorio, OrigenRepositorio>();
        services.AddTransient<IOrigenDAC, OrigenDAC>();
        services.AddTransient<IPosicionRepositorio, PosicionRepositorio>();
        services.AddTransient<IPosicionDAC, PosicionDAC>();
        services.AddTransient<ITipoFaltaRepositorio, TipoFaltaRepositorio>();
        services.AddTransient<ITipoFaltaDAC, TipoFaltaDAC>();
        services.AddTransient<ITipoGolRepositorio, TipoGolRepositorio>();
        services.AddTransient<ITipoGolDAC, TipoGolDAC>();
        services.AddTransient<ITipoMotivoRepositorio, TipoMotivoRepositorio>();
        services.AddTransient<ITipoMotivoDAC, TipoMotivoDAC>();
        return services;
    }
}
