namespace S4.Repositorio.ServiciosRepositorio.GeneralServicios.Interfaces
{
    public interface ITorneoRepositorio
    {
        Task<List<Torneo>> ListaTorneos();
        Task<Torneo> ObtieneTorneo(int IdTorneo);
        Task<Torneo> InsertaTorneo(Torneo torneo);
        Task<Torneo> ActualizaTorneo(Torneo torneo);
    }
}
