namespace S4.Repositorio.ServiciosRepositorio.JugadoresServicios;

public class JugadoresRepositorio : IJugadoresRepositorio
{
    public IJugadorDAC _jugadorDAC;
    public JugadoresRepositorio(IJugadorDAC jugadorDAC)
    {
        _jugadorDAC = jugadorDAC;
    }
    public async Task<JugadorDTO> ActualizaJugador(Jugador jugador)
    {
        var ActualizaJugador = await _jugadorDAC.ActualizarJugador(jugador);
        if (ActualizaJugador)
        {
            var InformacionJugadorActualizado = await _jugadorDAC.ObtieneJugador(jugador.IdJugador);
            return InformacionJugadorActualizado;
        }

        else
            return new JugadorDTO();
    }

    public async Task<JugadorDTO> InsertaJugador(Jugador jugador)
    {
        JugadorDTO jugadorInsertado = new JugadorDTO();
        var InsertaJugador = await _jugadorDAC.InsertarJugador(jugador);
        if (InsertaJugador > 0)
            jugadorInsertado = await _jugadorDAC.ObtieneJugador(InsertaJugador);
        else
            jugadorInsertado = new JugadorDTO();

        return jugadorInsertado;
    }

    public async Task<JugadorDTO> ObtieneJugador(int IdJugador)
    {
        var Jugador = await _jugadorDAC.ObtieneJugador(IdJugador);
        return Jugador;
    }

    public async Task<List<JugadorDTO>> ListaJugadores()
    {
        var ListaJugador = await _jugadorDAC.ListaJugador();
        return ListaJugador;
    }
}
