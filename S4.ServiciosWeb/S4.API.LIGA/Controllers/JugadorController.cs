namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class JugadorController : Controller
{
    private readonly ILogger<JugadorController> _logger;
    private readonly IJugadoresRepositorio _jugadoresRepositorio;
    public JugadorController(ILogger<JugadorController> logger, IJugadoresRepositorio jugadoresRepositorio)
    {
        _logger = logger;
        _jugadoresRepositorio = jugadoresRepositorio;
    }

    [HttpGet]
    public async Task<List<JugadorDTO>> ListaJugadores()
    {
        return await _jugadoresRepositorio.ListaJugadores();
    }
    [HttpGet]
    [Route("ObtieneJugador/{IdJugador}")]
    public async Task<JugadorDTO> ObtieneJuagdor(int IdJugador)
    {
        if (IdJugador > 0)
            return await _jugadoresRepositorio.ObtieneJugador(IdJugador);
        else
            return new JugadorDTO();
    }

    [HttpPost]
    public async Task<JugadorDTO> InsertaJuagdor(Jugador jugador)
    {
        return await _jugadoresRepositorio.InsertaJugador(jugador);
    }
    [HttpPut]
    public async Task<JugadorDTO> ActualizaJugador(Jugador jugador)
    {
        if (jugador == null)
            throw new Exception("No contienen informacion");
        if (jugador.IdJugador == 0)
            throw new Exception("No contienen el IdJugador para modificar el datos");

        return await _jugadoresRepositorio.ActualizaJugador(jugador);
    }

}
