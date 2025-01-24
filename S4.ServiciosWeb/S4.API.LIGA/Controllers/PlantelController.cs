namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class PlantelController : Controller
{
    private readonly ILogger<PlantelController> _logger;
    private readonly IPlantelRepositorio _plantelRepositorio;
    public PlantelController(ILogger<PlantelController> logger, IPlantelRepositorio plantelRepositorio)
    {
        _logger = logger;
        _plantelRepositorio = plantelRepositorio;
    }

    [HttpGet]
    public async Task<List<PlantelDTO>> listaPlanteles()
    {
        return await _plantelRepositorio.ListaPlantel();
    }
    [HttpGet]
    [Route("ObtienePlantel/{IdPlantel}")]
    public async Task<PlantelDTO> ObtienePlantel(int IdPlantel)
    {
        if (IdPlantel > 0)
            return await _plantelRepositorio.ObtienePlantel(IdPlantel);
        else
            return new PlantelDTO();
    }

    [HttpPost]
    public async Task<PlantelDTO> InsertaPlantel(Plantel plantel)
    {
        return await _plantelRepositorio.InsertaPlantel(plantel);
    }
    [HttpPut]
    public async Task<PlantelDTO> ActualizaPlantel(Plantel plantel)
    {
        if (plantel == null)
            throw new Exception("No contienen informacion");
        if (plantel.IdPlantel == 0)
            throw new Exception("No contienen el IdPlantel para modificar el datos");

        return await _plantelRepositorio.ActualizaPlantel(plantel);
    }
}
