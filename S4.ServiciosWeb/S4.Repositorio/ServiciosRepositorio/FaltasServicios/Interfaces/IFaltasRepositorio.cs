namespace S4.Repositorio.ServiciosRepositorio.FaltasServicios.Interfaces;

public interface IFaltasRepositorio
{
    Task<List<FaltaDTO>> ListaFaltas();
    Task<FaltaDTO> ObtieneFalta(int IdFalta);
    Task<FaltaDTO> InsertaFalta(Falta falta);
    Task<FaltaDTO> ActualizaFalta(Falta falta);
}
