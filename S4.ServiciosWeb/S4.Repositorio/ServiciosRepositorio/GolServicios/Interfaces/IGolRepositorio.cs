namespace S4.Repositorio.ServiciosRepositorio.GolServicios.Interfaces;

public interface IGolRepositorio
{
    Task<List<Gol>> ObtienelistaGol();
    Task<Gol> ObtieneGol(int IdGol);
    Task<Gol> InsertaGol(Gol gol);
    Task<Gol> ActualizaGol(Gol gol);
}
