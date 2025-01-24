namespace S4.API.LIGA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GolController : Controller
    {
        private readonly ILogger<GolController> _logger;
        private readonly IGolRepositorio _golRepositorio;
        public GolController(ILogger<GolController> logger, IGolRepositorio golRepositorio)
        {
            _logger = logger;
            _golRepositorio = golRepositorio;
        }

        [HttpGet]
        public async Task<List<Gol>> ListaGoles()
        {
            return await _golRepositorio.ObtienelistaGol();
        }
        [HttpGet]
        [Route("ObtieneGol/{IdJugador}")]
        public async Task<Gol> ObtieneGol(int IdGol)
        {
            if (IdGol > 0)
                return await _golRepositorio.ObtieneGol(IdGol);
            else
                return new Gol();
        }

        [HttpPost]
        public async Task<Gol> InsertaGol(Gol gol)
        {
            return await _golRepositorio.InsertaGol(gol);
        }
        [HttpPut]
        public async Task<Gol> ActualizaGol(Gol gol)
        {
            if (gol == null)
                throw new Exception("No contienen informacion");
            if (gol.IdGol == 0)
                throw new Exception("No contienen el IdGol para modificar el datos");

            return await _golRepositorio.ActualizaGol(gol);
        }
    }
}
