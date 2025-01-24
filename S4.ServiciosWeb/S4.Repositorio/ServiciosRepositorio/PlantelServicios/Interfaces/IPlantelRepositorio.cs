namespace S4.Repositorio.ServiciosRepositorio.PlantelServicios.Interfaces;

public interface IPlantelRepositorio
{
    Task<List<PlantelDTO>> ListaPlantel();
    Task<PlantelDTO> ObtienePlantel(int IdPlantel);
    Task<PlantelDTO> InsertaPlantel(Plantel plantel);
    Task<PlantelDTO> ActualizaPlantel(Plantel plantel);
}
