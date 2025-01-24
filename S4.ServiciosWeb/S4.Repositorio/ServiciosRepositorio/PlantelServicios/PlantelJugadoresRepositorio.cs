namespace S4.Repositorio.ServiciosRepositorio.PlantelServicios;

public class PlantelJugadoresRepositorio : IPlantelJugadoresRepositorio
{
    private readonly IPlantelJugadorDAC _plantelJugadorDAC;
    public PlantelJugadoresRepositorio(IPlantelJugadorDAC plantelJugadorDAC)
    {
        _plantelJugadorDAC = plantelJugadorDAC;
    }

    public async Task<PlantelJugadorDTO> ActualizaPlantelJugador(PlantelJugador plantelJugador)
    {
        var ActualizaPlantelJuagador = await _plantelJugadorDAC.ActualizarPlantelJugador(plantelJugador);
        if (ActualizaPlantelJuagador)
        {
            var InformacionPlantelJuagadorActualizado = await _plantelJugadorDAC.ObtienePlantelJugador(plantelJugador.IdPlantelJugador);
            return InformacionPlantelJuagadorActualizado;
        }
        else
            return new PlantelJugadorDTO();
    }

    public async Task<PlantelJugadorDTO> InsertaPlantelJugador(PlantelJugador plantelJugador)
    {
        PlantelJugadorDTO plantelJuagdorInsertado = new PlantelJugadorDTO();
        var InsertaPlantelJugador = await _plantelJugadorDAC.InsertarPlantelJugador(plantelJugador);
        if (InsertaPlantelJugador > 0)
            plantelJuagdorInsertado = await _plantelJugadorDAC.ObtienePlantelJugador(InsertaPlantelJugador);
        else
            plantelJuagdorInsertado = new PlantelJugadorDTO();

        return plantelJuagdorInsertado;
    }

    public async Task<List<PlantelJugadorDTO>> ListaPlantelJugadores()
    {
        var obtieneListaPlantelJugador = await _plantelJugadorDAC.ListaPlantelJugador();
        return obtieneListaPlantelJugador;
    }

    public async Task<PlantelJugadorDTO> ObtienePlantelJugador(int IdPlantelJugador)
    {
        var obtienePlantelJugador = await _plantelJugadorDAC.ObtienePlantelJugador(IdPlantelJugador);
        return obtienePlantelJugador;
    }
}
