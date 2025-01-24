namespace S4.Repositorio.ServiciosRepositorio.CambiosServicios.Interfaces;

public interface ICambiosRepositorio
{
    Task<List<CambioDTO>> ListaCambio();
    Task<CambioDTO> ObtieneCambio(int IdCambio);
    Task<CambioDTO> InsertaCambio(Cambio cambio);
    Task<CambioDTO> ActualizaCambio(Cambio cambio);
}
