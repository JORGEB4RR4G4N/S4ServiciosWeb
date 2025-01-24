namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios;

public class TipoGolRepositorio : ITipoGolRepositorio
{
    private readonly ITipoGolDAC _tipoGolDAC;
    public TipoGolRepositorio(ITipoGolDAC tipoGolDAC)
    {
        _tipoGolDAC = tipoGolDAC;
    }

    public async Task<TipoGol> ActualizaTipoGol(TipoGol tipoGol)
    {
        var ActualizaTipoMotivo = await _tipoGolDAC.ActualizarTipoGol(tipoGol);
        if (ActualizaTipoMotivo)
        {
            var InformacionTipoMotivoActualizado = await _tipoGolDAC.obtieneTipoGol(tipoGol.IdTipoGol);
            return InformacionTipoMotivoActualizado;
        }
        else
            return new TipoGol();
    }

    public async Task<TipoGol> InsertaTipoGol(TipoGol tipoGol)
    {
        TipoGol tipoGolInsertado = new TipoGol();
        var InsertaTipoGol = await _tipoGolDAC.InsertarTipoGol(tipoGol);
        if (InsertaTipoGol > 0)
            tipoGol = await _tipoGolDAC.obtieneTipoGol(InsertaTipoGol);
        else
            tipoGol = new TipoGol();

        return tipoGol;
    }

    public async Task<List<TipoGol>> ListaTipoGoles()
    {
        var obtieneListaTipoMotivo = await _tipoGolDAC.ListaTipoGol();
        return obtieneListaTipoMotivo;
    }

    public async Task<TipoGol> ObtieneTipoGol(int idTipoGol)
    {
        var obtieneTipoMotivo = await _tipoGolDAC.obtieneTipoGol(idTipoGol);
        return obtieneTipoMotivo;
    }
}
