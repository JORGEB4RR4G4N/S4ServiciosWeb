namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios.Interfaces;

public interface ITipoGolRepositorio
{
    Task<List<TipoGol>> ListaTipoGoles();
    Task<TipoGol> ObtieneTipoGol(int idTipoGol);
    Task<TipoGol> InsertaTipoGol(TipoGol tipoGol);
    Task<TipoGol> ActualizaTipoGol(TipoGol tipoGol);
}
