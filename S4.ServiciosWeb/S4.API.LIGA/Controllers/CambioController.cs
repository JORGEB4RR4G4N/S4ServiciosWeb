namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class CambioController : Controller
{
    private readonly ILogger<CambioController> _logger;
    private readonly ICambiosRepositorio _cambiosRepositorio;
    public CambioController(ILogger<CambioController> logger, ICambiosRepositorio cambiosRepositorio)
    {
        _logger = logger;
        _cambiosRepositorio = cambiosRepositorio;
    }

    [HttpGet]
    public async Task<List<CambioDTO>> ListaCambio()
    {
        return await _cambiosRepositorio.ListaCambio();
    }
    [HttpGet]
    [Route("ObtieneCambio/{IdCambio}")]
    public async Task<CambioDTO> ObtieneCambio(int IdCambio)
    {
        if (IdCambio > 0)
            return await _cambiosRepositorio.ObtieneCambio(IdCambio);
        else
            return new CambioDTO();
    }

    [HttpPost]
    public async Task<CambioDTO> InsertaCambio(Cambio cambio)
    {
        return await _cambiosRepositorio.InsertaCambio(cambio);
    }
    [HttpPut]
    public async Task<CambioDTO> ActualizaCambio(Cambio cambio)
    {
        if (cambio == null)
            throw new Exception("No contienen informacion");
        if (cambio.IdCambio == 0)
            throw new Exception("No contienen el IdCambio para modificar el datos");

        return await _cambiosRepositorio.ActualizaCambio(cambio);
    }
}
