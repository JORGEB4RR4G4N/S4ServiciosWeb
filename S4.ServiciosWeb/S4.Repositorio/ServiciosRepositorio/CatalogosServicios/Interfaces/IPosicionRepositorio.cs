namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios.Interfaces;
public interface IPosicionRepositorio
{
    Task<List<Posicion>> ListaPosiciones();
    Task<Posicion> ObtienePosicion(int IdPosicion);
    Task<Posicion> InsertaPosicion(Posicion posicion);
    Task<Posicion> ActualizaPosicion(Posicion posicion);
}
