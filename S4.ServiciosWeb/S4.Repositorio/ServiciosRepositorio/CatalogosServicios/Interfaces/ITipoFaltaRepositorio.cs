namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios.Interfaces;
public interface ITipoFaltaRepositorio
{
    Task<List<TipoFalta>> ListaTipoFalta();
    Task<TipoFalta> ObtieneTipoFalta(int idTipoFalta);
    Task<TipoFalta> InsertaTipoFalta(TipoFalta tipoFalta);
    Task<TipoFalta> ActualizaTipoFalta(TipoFalta tipoFalta);
}
