namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class TipoMotivoController : Controller
{
    private readonly ILogger<TipoMotivoController> _logger;
    private readonly ITipoMotivoRepositorio _tipoMotivoRepositorio;
    public TipoMotivoController(ILogger<TipoMotivoController> logger, ITipoMotivoRepositorio tipoMotivoRepositorio)
    {
        _logger = logger;
        _tipoMotivoRepositorio = tipoMotivoRepositorio;
    }

    [HttpGet]
    public async Task<List<TipoMotivo>> ListaTipoMotivos()
    {
        return await _tipoMotivoRepositorio.listaTipoMotivos();
    }
    [HttpGet]
    [Route("ObtieneTipoMotivo/{IdTipoMotivol}")]
    public async Task<TipoMotivo> ObtieneTipoMotivo(int IdTipoMotivo)
    {
        if (IdTipoMotivo > 0)
            return await _tipoMotivoRepositorio.ObtieneTipoMotivo(IdTipoMotivo);
        else
            return new TipoMotivo();
    }

    [HttpPost]
    public async Task<TipoMotivo> InsertaTipoGol(TipoMotivo tipoGol)
    {
        return await _tipoMotivoRepositorio.InsertaTipoMotivo(tipoGol);
    }
    [HttpPut]
    public async Task<TipoMotivo> ActualizaTipoGol(TipoMotivo tipoGol)
    {
        if (tipoGol == null)
            throw new Exception("No contienen informacion");
        if (tipoGol.IdTipoMotivo == 0)
            throw new Exception("No contienen el IdTipoMotivo para modificar el datos");

        return await _tipoMotivoRepositorio.ActualizaTipoMotivo(tipoGol);
    }
}
