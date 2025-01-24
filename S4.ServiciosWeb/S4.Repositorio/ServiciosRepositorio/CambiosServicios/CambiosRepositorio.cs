namespace S4.Repositorio.ServiciosRepositorio.CambiosServicios;

public class CambiosRepositorio : ICambiosRepositorio
{
    private readonly ICambioDAC _cambioDAC;
    public CambiosRepositorio(ICambioDAC cambioDAC)
    {
        _cambioDAC = cambioDAC;
    }

    public async Task<CambioDTO> ActualizaCambio(Cambio cambio)
    {
        var ActualizaCambio = await _cambioDAC.ActualizarCambio(cambio);
        if (ActualizaCambio)
        {
            var InformacionCambioActualizado = await _cambioDAC.ObtenCambio(cambio.IdCambio);
            return InformacionCambioActualizado;
        }
        else
            return new CambioDTO();
    }

    public async Task<CambioDTO> InsertaCambio(Cambio cambio)
    {
        CambioDTO cambioInsertado = new CambioDTO();
        var InsertaCambio = await _cambioDAC.InsertarCambio(cambio);
        if (InsertaCambio > 0)
            cambioInsertado = await _cambioDAC.ObtenCambio(InsertaCambio);
        else
            cambioInsertado = new CambioDTO();

        return cambioInsertado;
    }

    public async Task<List<CambioDTO>> ListaCambio()
    {
        var obtieneListaPosicion = await _cambioDAC.ListaCambio();
        return obtieneListaPosicion;
    }

    public async Task<CambioDTO> ObtieneCambio(int IdCambio)
    {
        var obtieneCambio = await _cambioDAC.ObtenCambio(IdCambio);
        return obtieneCambio;
    }
}
