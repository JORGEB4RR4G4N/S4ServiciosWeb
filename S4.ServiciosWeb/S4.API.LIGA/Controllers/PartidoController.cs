namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class PartidoController : Controller
{
    private readonly ILogger<PartidoController> _logger;
    private readonly IPartidoRepositorio _partidoRepositorio;
    public PartidoController(ILogger<PartidoController> logger, IPartidoRepositorio partidoRepositorio)
    {
        _logger = logger;
        _partidoRepositorio = partidoRepositorio;
    }

    [HttpGet]
    public async Task<List<PartidoDTO>> ListaPartido()
    {
        return await _partidoRepositorio.ObtienelistaPartido();
    }
    [HttpGet]
    [Route("ObtienePartido/{IdPartido}")]
    public async Task<PartidoDTO> ObtienePartido(int IdPartido)
    {
        if (IdPartido > 0)
            return await _partidoRepositorio.ObtienePartido(IdPartido);
        else
            return new PartidoDTO();
    }

    [HttpPost]
    public async Task<PartidoDTO> InsertaPartido(Partido partido)
    {
        return await _partidoRepositorio.InsertaPartido(partido);
    }
    [HttpPut]
    public async Task<PartidoDTO> ActualizaPartido(Partido partido)
    {
        if (partido == null)
            throw new Exception("No contienen informacion");
        if (partido.IdPartido == 0)
            throw new Exception("No contienen el Idpartido para modificar el datos");

        return await _partidoRepositorio.ActualizaPartido(partido);
    }
}
