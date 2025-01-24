namespace S4.Repositorio.ServiciosRepositorio.PlantelServicios;

internal class PlantelRepositorio : IPlantelRepositorio
{
    private readonly IPlantelDAC _plantelDAC;

    public PlantelRepositorio(IPlantelDAC plantelDAC)
    {
        _plantelDAC = plantelDAC;
    }

    public async Task<PlantelDTO> ActualizaPlantel(Plantel plantel)
    {
        var ActualizaPlantel = await _plantelDAC.ActualizarPlantel(plantel);
        if (ActualizaPlantel)
        {
            var InformacionPlantelActualizado = await _plantelDAC.ObtienePlantel(plantel.IdPlantel);
            return InformacionPlantelActualizado;
        }
        else
            return new PlantelDTO();
    }

    public async Task<PlantelDTO> InsertaPlantel(Plantel plantel)
    {
        PlantelDTO plantelInsertado = new PlantelDTO();
        var InsertaPlantel = await _plantelDAC.InsertarPlantel(plantel);
        if (InsertaPlantel > 0)
            plantelInsertado = await _plantelDAC.ObtienePlantel(InsertaPlantel);
        else
            plantelInsertado = new PlantelDTO();

        return plantelInsertado;
    }

    public async Task<List<PlantelDTO>> ListaPlantel()
    {
        var obtieneListaPlantel = await _plantelDAC.ListaPlantel();
        return obtieneListaPlantel;
    }

    public async Task<PlantelDTO> ObtienePlantel(int IdPlantel)
    {
        var obtienePlantel = await _plantelDAC.ObtienePlantel(IdPlantel);
        return obtienePlantel;
    }
}
