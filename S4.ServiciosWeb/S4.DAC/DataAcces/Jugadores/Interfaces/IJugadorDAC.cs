namespace S4.DAC.DataAcces.Jugadores.Interfaces;

public interface IJugadorDAC
{
    Task<int> InsertarJugador(Jugador jugador);
    Task<bool> ActualizarJugador(Jugador jugador);
    Task<List<JugadorDTO>> ListaJugador();
    Task<JugadorDTO> ObtieneJugador(int jugador);
}
