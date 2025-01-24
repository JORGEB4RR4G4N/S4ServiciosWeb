namespace S4.API.LIGA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TorneoController : Controller
    {
        private readonly ILogger<TorneoController> _logger;
        private readonly ITorneoRepositorio _torneoRepositorio;
        public TorneoController(ILogger<TorneoController> logger, ITorneoRepositorio torneoServicio)
        {
            _logger = logger;
            _torneoRepositorio = torneoServicio;
        }

        [HttpGet]
        public async Task<List<Torneo>> ListaTorneos()
        {
            return await _torneoRepositorio.ListaTorneos();
        }
        [HttpGet]
        [Route("ObtieneTorneo/{IdTorneo}")]
        public async Task<Torneo> ObtieneTorneo(int IdTorneo)
        {
            if (IdTorneo > 0)
                return await _torneoRepositorio.ObtieneTorneo(IdTorneo);
            else
                return new Torneo();
        }

        [HttpPost]
        public async Task<Torneo> InsertaTorneo(Torneo torneo)
        {
            return await _torneoRepositorio.InsertaTorneo(torneo);
        }
        [HttpPut]
        public async Task<Torneo> ActualizaTorneo(Torneo torneo)
        {
            if (torneo == null)
                throw new Exception("No contienen informacion");
            if (torneo.IdTorneo == 0)
                throw new Exception("No contienen el IdTorneo para modificar el datos");

            return await _torneoRepositorio.ActualizaTorneo(torneo);
        }


    }
}
