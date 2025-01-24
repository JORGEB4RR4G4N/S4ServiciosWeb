namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios.Interfaces;

public interface ITipoMotivoRepositorio
{
    Task<List<TipoMotivo>> listaTipoMotivos();
    Task<TipoMotivo> ObtieneTipoMotivo(int IdTipoMotivo);
    Task<TipoMotivo> InsertaTipoMotivo(TipoMotivo tipoMotivo);
    Task<TipoMotivo> ActualizaTipoMotivo(TipoMotivo tipoMotivo);
}
