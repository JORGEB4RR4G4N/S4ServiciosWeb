namespace S4.Repositorio.ServiciosRepositorio.CatalogosServicios;

public class TipoMotivoRepositorio : ITipoMotivoRepositorio
{
    private readonly ITipoMotivoDAC _tipoMotivoDAC;
    public TipoMotivoRepositorio(ITipoMotivoDAC tipoMotivoDAC)
    {
        _tipoMotivoDAC = tipoMotivoDAC;
    }

    public async Task<TipoMotivo> ActualizaTipoMotivo(TipoMotivo tipoMotivo)
    {
        var ActualizaTipoMotivo = await _tipoMotivoDAC.ActualizarTipoMotivo(tipoMotivo);
        if (ActualizaTipoMotivo)
        {
            var InformacionTipoMotivoActualizado = await _tipoMotivoDAC.obtieneTipoMotivo(tipoMotivo.IdTipoMotivo);
            return InformacionTipoMotivoActualizado;
        }
        else
            return new TipoMotivo();
    }

    public async Task<TipoMotivo> InsertaTipoMotivo(TipoMotivo tipoMotivo)
    {
        TipoMotivo tipoMotivoInsertado = new TipoMotivo();
        var InsertaTipoMotivo = await _tipoMotivoDAC.InsertarTipoMotivo(tipoMotivo);
        if (InsertaTipoMotivo > 0)
            tipoMotivoInsertado = await _tipoMotivoDAC.obtieneTipoMotivo(InsertaTipoMotivo);
        else
            tipoMotivoInsertado = new TipoMotivo();

        return tipoMotivoInsertado;
    }

    public async Task<List<TipoMotivo>> listaTipoMotivos()
    {
        var obtieneListaTipoMotivo = await _tipoMotivoDAC.ListaTipoMotivo();
        return obtieneListaTipoMotivo;
    }

    public async Task<TipoMotivo> ObtieneTipoMotivo(int IdTipoMotivo)
    {
        var obtieneTipoMotivo = await _tipoMotivoDAC.obtieneTipoMotivo(IdTipoMotivo);
        return obtieneTipoMotivo;
    }
}
