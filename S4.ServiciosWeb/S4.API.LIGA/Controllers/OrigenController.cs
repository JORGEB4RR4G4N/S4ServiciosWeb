namespace S4.API.LIGA.Controllers;


[Route("[controller]")]
[ApiController]
public class OrigenController : Controller
{
    private readonly ILogger<OrigenController> _logger;
    private readonly IOrigenRepositorio _origenRepositorio;
    public OrigenController(ILogger<OrigenController> logger, IOrigenRepositorio origenRepositorio)
    {
        _logger = logger;
        _origenRepositorio = origenRepositorio;
    }

    [HttpGet]
    public async Task<List<Origen>> ListaOrigen()
    {
        return await _origenRepositorio.listaOrigen();
    }
    [HttpGet]
    [Route("ObtieneOrigen/{IdOrigen}")]
    public async Task<Origen> ObtieneOrigen(int IdOrigen)
    {
        if (IdOrigen > 0)
            return await _origenRepositorio.ObtieneOrigen(IdOrigen);
        else
            return new Origen();
    }

    [HttpPost]
    public async Task<Origen> InsertaOrigen(Origen origen)
    {
        return await _origenRepositorio.InsertaOrigen(origen);
    }
    [HttpPut]
    public async Task<Origen> ActualizaOrigen(Origen origen)
    {
        if (origen == null)
            throw new Exception("No contienen informacion");
        if (origen.IdOrigen == 0)
            throw new Exception("No contienen el IdOrigen para modificar el datos");

        return await _origenRepositorio.ActualizaOrigen(origen);
    }
}
