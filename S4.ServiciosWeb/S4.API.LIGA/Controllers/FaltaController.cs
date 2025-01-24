namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class FaltaController : Controller
{
    private readonly ILogger<FaltaController> _logger;
    private readonly IFaltasRepositorio _faltaRepositorio;
    public FaltaController(ILogger<FaltaController> logger, IFaltasRepositorio faltaRepositorio)
    {
        _logger = logger;
        _faltaRepositorio = faltaRepositorio;
    }

    [HttpGet]
    public async Task<List<FaltaDTO>> ListaFalta()
    {
        return await _faltaRepositorio.ListaFaltas();
    }
    [HttpGet]
    [Route("ObtieneFalta/{IdFalta}")]
    public async Task<FaltaDTO> ObtieneFalta(int IdFalta)
    {
        if (IdFalta > 0)
            return await _faltaRepositorio.ObtieneFalta(IdFalta);
        else
            return new FaltaDTO();
    }

    [HttpPost]
    public async Task<FaltaDTO> InsertaFalta(Falta falta)
    {
        return await _faltaRepositorio.InsertaFalta(falta);
    }
    [HttpPut]
    public async Task<FaltaDTO> ActualizaFalta(Falta falta)
    {
        if (falta == null)
            throw new Exception("No contienen informacion");
        if (falta.IdFalta == 0)
            throw new Exception("No contienen el IdFalta para modificar el datos");

        return await _faltaRepositorio.ActualizaFalta(falta);
    }
}
