namespace S4.Repositorio.ServiciosRepositorio.GeneralServicios;

public class TorneoRepositorio : ITorneoRepositorio
{
    private ITorneoDAC _torneoRepositorio;
    public TorneoRepositorio(ITorneoDAC torneoRepositorio)
    {
        _torneoRepositorio = torneoRepositorio;
    }

    public async Task<Torneo> ActualizaTorneo(Torneo torneo)
    {
        var ActualizaTorneo = await _torneoRepositorio.ActualizaTorneo(torneo);
        if (ActualizaTorneo)
            return torneo;
        else
            return torneo = new Torneo();
    }

    public async Task<Torneo> InsertaTorneo(Torneo torneo)
    {
        var InsertaTorneo = await _torneoRepositorio.InsertaTorneo(torneo);
        if (InsertaTorneo > 0)
            torneo.IdTorneo = InsertaTorneo;
        else
            torneo = new Torneo();

        return torneo;
    }

    public async Task<List<Torneo>> ListaTorneos()
    {
        var ListaTorneo = await _torneoRepositorio.ObtieneTorneos();
        return ListaTorneo;
    }

    public async Task<Torneo> ObtieneTorneo(int IdTorneo)
    {
        var Torneo = await _torneoRepositorio.ObtieneTorneo(IdTorneo);
        return Torneo;
    }
}
