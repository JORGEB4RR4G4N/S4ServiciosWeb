namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios.Interfaces;

public interface IOrigenRepositorio
{
    Task<List<Origen>> listaOrigen();
    Task<Origen> ObtieneOrigen(int IdOrigen);
    Task<Origen> InsertaOrigen(Origen origen);
    Task<Origen> ActualizaOrigen(Origen origen);
}
