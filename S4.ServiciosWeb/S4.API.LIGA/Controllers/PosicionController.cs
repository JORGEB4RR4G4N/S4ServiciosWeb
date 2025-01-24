namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class PosicionController : Controller
{
    private readonly ILogger<PosicionController> _logger;
    private readonly IPosicionRepositorio _posicionRepositorio;
    public PosicionController(ILogger<PosicionController> logger, IPosicionRepositorio posicionRepositorio)
    {
        _logger = logger;
        _posicionRepositorio = posicionRepositorio;
    }

    [HttpGet]
    public async Task<List<Posicion>> ListaPosiciones()
    {
        return await _posicionRepositorio.ListaPosiciones();
    }
    [HttpGet]
    [Route("ObtienePosicion/{IdPosicion}")]
    public async Task<Posicion> ObtienePosicion(int IdPosicion)
    {
        if (IdPosicion > 0)
            return await _posicionRepositorio.ObtienePosicion(IdPosicion);
        else
            return new Posicion();
    }

    [HttpPost]
    public async Task<Posicion> InsertaPosicion(Posicion posicion)
    {
        return await _posicionRepositorio.InsertaPosicion(posicion);
    }
    [HttpPut]
    public async Task<Posicion> ActualizaPosicion(Posicion posicion)
    {
        if (posicion == null)
            throw new Exception("No contienen informacion");
        if (posicion.IdPosicion == 0)
            throw new Exception("No contienen el IdPosicion para modificar el datos");

        return await _posicionRepositorio.ActualizaPosicion(posicion);
    }
}
