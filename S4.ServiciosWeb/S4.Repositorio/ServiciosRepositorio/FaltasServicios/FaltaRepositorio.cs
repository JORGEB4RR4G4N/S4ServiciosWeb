namespace S4.Repositorio.ServiciosRepositorio.FaltasServicios;
public class FaltaRepositorio : IFaltasRepositorio
{
    private readonly IFaltasDAC _faltasDAC;
    public FaltaRepositorio(IFaltasDAC faltasDAC)
    {
        _faltasDAC = faltasDAC;
    }

    public async Task<FaltaDTO> ActualizaFalta(Falta falta)
    {
        var ActualizaFalta = await _faltasDAC.ActualizarFalta(falta);
        if (ActualizaFalta)
        {
            var InformacionTablaGeneralActualizado = await _faltasDAC.ObtieneFalta(falta.IdFalta);
            return InformacionTablaGeneralActualizado;
        }
        else
            return new FaltaDTO();
    }

    public async Task<FaltaDTO> InsertaFalta(Falta falta)
    {
        FaltaDTO faltaInsertado = new FaltaDTO();
        var InsertaFalta = await _faltasDAC.InsertarFalta(falta);
        if (InsertaFalta > 0)
            faltaInsertado = await _faltasDAC.ObtieneFalta(InsertaFalta);
        else
            faltaInsertado = new FaltaDTO();

        return faltaInsertado;
    }

    public async Task<List<FaltaDTO>> ListaFaltas()
    {
        var obtieneListaTablaGeneral = await _faltasDAC.ListaFalta();
        return obtieneListaTablaGeneral;
    }

    public async Task<FaltaDTO> ObtieneFalta(int IdFalta)
    {
        var obtieneTablaGeneral = await _faltasDAC.ObtieneFalta(IdFalta);
        return obtieneTablaGeneral;
    }
}
