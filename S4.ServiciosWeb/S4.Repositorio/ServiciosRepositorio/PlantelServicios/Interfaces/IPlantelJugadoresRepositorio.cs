namespace S4.Repositorio.ServiciosRepositorio.PlantelServicios.Interfaces;

public interface IPlantelJugadoresRepositorio
{
    Task<List<PlantelJugadorDTO>> ListaPlantelJugadores();
    Task<PlantelJugadorDTO> ObtienePlantelJugador(int IdPlantelJugador);
    Task<PlantelJugadorDTO> InsertaPlantelJugador(PlantelJugador plantelJugador);
    Task<PlantelJugadorDTO> ActualizaPlantelJugador(PlantelJugador plantelJugador);
}
