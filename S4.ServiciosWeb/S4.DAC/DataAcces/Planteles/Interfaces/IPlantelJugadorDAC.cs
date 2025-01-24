namespace S4.DAC.DataAcces.Planteles.Interfaces;

public interface IPlantelJugadorDAC
{
    Task<int> InsertarPlantelJugador(PlantelJugador planteljugador);
    Task<bool> ActualizarPlantelJugador(PlantelJugador planteljugador);
    Task<List<PlantelJugadorDTO>> ListaPlantelJugador();
    Task<PlantelJugadorDTO> ObtienePlantelJugador(int IdPlantelJugador);
}
