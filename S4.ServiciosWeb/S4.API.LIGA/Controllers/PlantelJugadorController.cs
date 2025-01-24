namespace S4.API.LIGA.Controllers;

[Route("[controller]")]
[ApiController]
public class PlantelJugadorController : Controller
{

    private readonly ILogger<PlantelJugadorController> _logger;
    private readonly IPlantelJugadoresRepositorio _plantelJugadoresRepositorio;
    public PlantelJugadorController(ILogger<PlantelJugadorController> logger, IPlantelJugadoresRepositorio plantelJugadoresRepositorio)
    {
        _logger = logger;
        _plantelJugadoresRepositorio = plantelJugadoresRepositorio;
    }

    [HttpGet]
    public async Task<List<PlantelJugadorDTO>> ListaPlantelJugadores()
    {
        return await _plantelJugadoresRepositorio.ListaPlantelJugadores();
    }
    [HttpGet]
    [Route("ObtienePlantelJuagdor/{IdPlantelJugadores}")]
    public async Task<PlantelJugadorDTO> ObtienePlantelJugador(int IdPlantelJugador)
    {
        if (IdPlantelJugador > 0)
            return await _plantelJugadoresRepositorio.ObtienePlantelJugador(IdPlantelJugador);
        else
            return new PlantelJugadorDTO();
    }

    [HttpPost]
    public async Task<PlantelJugadorDTO> InsertaPlantelJugador(PlantelJugador plantelJugador)
    {
        return await _plantelJugadoresRepositorio.InsertaPlantelJugador(plantelJugador);
    }
    [HttpPut]
    public async Task<PlantelJugadorDTO> ActualizaPlantelJugador(PlantelJugador plantelJugador)
    {
        if (plantelJugador == null)
            throw new Exception("No contienen informacion");
        if (plantelJugador.IdPlantelJugador == 0)
            throw new Exception("No contienen el IdPlantelJugador para modificar el datos");

        return await _plantelJugadoresRepositorio.ActualizaPlantelJugador(plantelJugador);
    }
}
