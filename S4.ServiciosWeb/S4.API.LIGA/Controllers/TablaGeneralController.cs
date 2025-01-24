namespace S4.API.LIGA.Controllers;


[Route("[controller]")]
[ApiController]
public class TablaGeneralController : Controller
{
    private readonly ILogger<TablaGeneralController> _logger;
    private readonly ITablaGeneralRepositorio _tablaGeneralRepositorio;
    public TablaGeneralController(ILogger<TablaGeneralController> logger, ITablaGeneralRepositorio tablaGeneralRepositorio)
    {
        _logger = logger;
        _tablaGeneralRepositorio = tablaGeneralRepositorio;
    }

    [HttpGet]
    public async Task<List<TablaGeneralDTO>> ListaTablaGeneral()
    {
        return await _tablaGeneralRepositorio.listaTablaGeneral();
    }
    [HttpGet]
    [Route("ObtieneTablaGeneral/{IdTablaGeneral}")]
    public async Task<TablaGeneralDTO> ObtieneTablaGeneral(int IdTablaGeneral)
    {
        if (IdTablaGeneral > 0)
            return await _tablaGeneralRepositorio.ObtieneTablaGeneral(IdTablaGeneral);
        else
            return new TablaGeneralDTO();
    }

    [HttpPost]
    public async Task<TablaGeneralDTO> InsertaTablaGeneral(TablaGeneral tablaGeneral)
    {
        return await _tablaGeneralRepositorio.InsertaTablaGeneral(tablaGeneral);
    }
    [HttpPut]
    public async Task<TablaGeneralDTO> ActualizaTablaGeneral(TablaGeneral tablaGeneral)
    {
        if (tablaGeneral == null)
            throw new Exception("No contienen informacion");
        if (tablaGeneral.IdTablaGeneral == 0)
            throw new Exception("No contienen el IdtablaGeneral para modificar el datos");

        return await _tablaGeneralRepositorio.ActualizaTablaGeneral(tablaGeneral);
    }
}
