namespace S4.Repositorio.ServiciosRepositorio.GeneralServicios;

public class PartidoRepositorio : IPartidoRepositorio
{
    private readonly IPartidoDAC _partidoDAC;
    public PartidoRepositorio(IPartidoDAC partidoDAC)
    {
        _partidoDAC = partidoDAC;
    }

    public async Task<PartidoDTO> ActualizaPartido(Partido partido)
    {
        var ActualizaPlantel = await _partidoDAC.ActualizaPartido(partido);
        if (ActualizaPlantel)
        {
            var InformacionPlantelActualizado = await _partidoDAC.ObtienePartido(partido.IdPartido);
            return InformacionPlantelActualizado;
        }
        else
            return new PartidoDTO();
    }

    public async Task<PartidoDTO> InsertaPartido(Partido partido)
    {
        PartidoDTO partidoInsertado = new PartidoDTO();
        var InsertaPartido = await _partidoDAC.InsertaPartido(partido);
        if (InsertaPartido > 0)
            partidoInsertado = await _partidoDAC.ObtienePartido(InsertaPartido);
        else
            partidoInsertado = new PartidoDTO();

        return partidoInsertado;
    }

    public async Task<List<PartidoDTO>> ObtienelistaPartido()
    {
        var obtieneListaPartidos = await _partidoDAC.ListaPartidos();
        return obtieneListaPartidos;
    }

    public async Task<PartidoDTO> ObtienePartido(int IdPartido)
    {
        var obtienePartido = await _partidoDAC.ObtienePartido(IdPartido);
        return obtienePartido;
    }
}
