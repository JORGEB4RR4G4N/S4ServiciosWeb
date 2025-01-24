namespace S4.Repositorio.ServiciosRepositorio.PlantelServicios.Extensiones;

public static class PlantelesExtension
{
    public static IServiceCollection addPlantelesExtension(this IServiceCollection services)
    {
        services.AddTransient<IPlantelRepositorio, PlantelRepositorio>();
        services.AddTransient<IPlantelDAC, PlantelDAC>();

        services.AddTransient<IPlantelJugadoresRepositorio, PlantelJugadoresRepositorio>();
        services.AddTransient<IPlantelJugadorDAC, PlantelJugadorDAC>();

        return services;
    }
}
