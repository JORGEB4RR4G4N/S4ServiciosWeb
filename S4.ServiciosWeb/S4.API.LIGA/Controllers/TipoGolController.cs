namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class TipoGolController : Controller
{
    private readonly ILogger<TipoGolController> _logger;
    private readonly ITipoGolRepositorio _tipoGolRepositorio;
    public TipoGolController(ILogger<TipoGolController> logger, ITipoGolRepositorio tipoGolRepositorio)
    {
        _logger = logger;
        _tipoGolRepositorio = tipoGolRepositorio;
    }

    [HttpGet]
    public async Task<List<TipoGol>> ListaTipoGoles()
    {
        return await _tipoGolRepositorio.ListaTipoGoles();
    }
    [HttpGet]
    [Route("ObtieneTipoGol/{IdTipoGol}")]
    public async Task<TipoGol> ObtieneTipoGol(int IdTipoGol)
    {
        if (IdTipoGol > 0)
            return await _tipoGolRepositorio.ObtieneTipoGol(IdTipoGol);
        else
            return new TipoGol();
    }

    [HttpPost]
    public async Task<TipoGol> InsertaTipoGol(TipoGol tipoGol)
    {
        return await _tipoGolRepositorio.InsertaTipoGol(tipoGol);
    }
    [HttpPut]
    public async Task<TipoGol> ActualizaTipoGol(TipoGol tipoGol)
    {
        if (tipoGol == null)
            throw new Exception("No contienen informacion");
        if (tipoGol.IdTipoGol == 0)
            throw new Exception("No contienen el IdTipoGol para modificar el datos");

        return await _tipoGolRepositorio.ActualizaTipoGol(tipoGol);
    }
}
