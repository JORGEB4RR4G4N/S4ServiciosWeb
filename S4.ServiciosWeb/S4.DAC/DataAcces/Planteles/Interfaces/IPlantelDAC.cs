namespace S4.DAC.DataAcces.Planteles.Interfaces;

public interface IPlantelDAC
{
    Task<int> InsertarPlantel(Plantel plantel);
    Task<bool> ActualizarPlantel(Plantel plantel);
    Task<List<PlantelDTO>> ListaPlantel();
    Task<PlantelDTO> ObtienePlantel(int IdPlantel);
}
