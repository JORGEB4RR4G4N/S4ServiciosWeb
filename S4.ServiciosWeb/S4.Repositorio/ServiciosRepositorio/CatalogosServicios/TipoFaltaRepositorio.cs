namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios;

public class TipoFaltaRepositorio : ITipoFaltaRepositorio
{
    private readonly ITipoFaltaDAC _tipoFaltaDAC;
    public TipoFaltaRepositorio(ITipoFaltaDAC tipoFaltaDAC)
    {
        _tipoFaltaDAC = tipoFaltaDAC;
    }

    public async Task<TipoFalta> ActualizaTipoFalta(TipoFalta tipoFalta)
    {
        var ActualizaTipoFalta = await _tipoFaltaDAC.ActualizarTipoFalta(tipoFalta);
        if (ActualizaTipoFalta)
        {
            var InformacionTipoFaltaActualizado = await _tipoFaltaDAC.obtieneTipoFaltas(tipoFalta.IdTipoFalta);
            return InformacionTipoFaltaActualizado;
        }
        else
            return new TipoFalta();
    }

    public async Task<TipoFalta> InsertaTipoFalta(TipoFalta tipoFalta)
    {
        TipoFalta tipoFaltaInsertado = new TipoFalta();
        var InsertaTipoFalta = await _tipoFaltaDAC.InsertarTipoFalta(tipoFalta);
        if (InsertaTipoFalta > 0)
            tipoFaltaInsertado = await _tipoFaltaDAC.obtieneTipoFaltas(InsertaTipoFalta);
        else
            tipoFaltaInsertado = new TipoFalta();

        return tipoFaltaInsertado;
    }

    public async Task<List<TipoFalta>> ListaTipoFalta()
    {
        var obtieneListaTipoMotivo = await _tipoFaltaDAC.ListaTipoFaltas();
        return obtieneListaTipoMotivo;
    }

    public async Task<TipoFalta> ObtieneTipoFalta(int idTipoFalta)
    {
        var obtieneTipoMotivo = await _tipoFaltaDAC.obtieneTipoFaltas(idTipoFalta);
        return obtieneTipoMotivo;
    }
}
