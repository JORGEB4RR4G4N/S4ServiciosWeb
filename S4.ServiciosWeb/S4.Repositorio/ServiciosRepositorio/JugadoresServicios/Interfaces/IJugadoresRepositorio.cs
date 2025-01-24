namespace S4.Repositorio.ServiciosRepositorio.JugadoresServicios.Interfaces;

public interface IJugadoresRepositorio
{
    Task<List<JugadorDTO>> ListaJugadores();
    Task<JugadorDTO> ObtieneJugador(int IdJugador);
    Task<JugadorDTO> InsertaJugador(Jugador jugador);
    Task<JugadorDTO> ActualizaJugador(Jugador jugador);
}
