namespace S4.Repositorio.ServiciosRepositorio.GeneralServicios.Interfaces;

public interface IPartidoRepositorio
{
    Task<List<PartidoDTO>> ObtienelistaPartido();
    Task<PartidoDTO> ObtienePartido(int IdPartido);
    Task<PartidoDTO> InsertaPartido(Partido partido);
    Task<PartidoDTO> ActualizaPartido(Partido partido);
}
