namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class TipoFaltaController : Controller
{
    private readonly ILogger<TipoFaltaController> _logger;
    private readonly ITipoFaltaRepositorio _tipoFaltaRepositorio;
    public TipoFaltaController(ILogger<TipoFaltaController> logger, ITipoFaltaRepositorio tipoFaltaRepositorio)
    {
        _logger = logger;
        _tipoFaltaRepositorio = tipoFaltaRepositorio;
    }

    [HttpGet]
    public async Task<List<TipoFalta>> ListaTipoFalta()
    {
        return await _tipoFaltaRepositorio.ListaTipoFalta();
    }
    [HttpGet]
    [Route("ObtieneTipoFalta/{IdTipoFalta}")]
    public async Task<TipoFalta> ObtieneTipoFalta(int IdTipoFalta)
    {
        if (IdTipoFalta > 0)
            return await _tipoFaltaRepositorio.ObtieneTipoFalta(IdTipoFalta);
        else
            return new TipoFalta();
    }

    [HttpPost]
    public async Task<TipoFalta> InsertaTipoFalta(TipoFalta tipoFalta)
    {
        return await _tipoFaltaRepositorio.InsertaTipoFalta(tipoFalta);
    }
    [HttpPut]
    public async Task<TipoFalta> ActualizaTipoFalta(TipoFalta tipoFalta)
    {
        if (tipoFalta == null)
            throw new Exception("No contienen informacion");
        if (tipoFalta.IdTipoFalta == 0)
            throw new Exception("No contienen el IdTipoFalta para modificar el datos");

        return await _tipoFaltaRepositorio.ActualizaTipoFalta(tipoFalta);
    }
}
