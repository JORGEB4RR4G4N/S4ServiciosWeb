namespace S4.DAC.DataAcces.Catalogos.Interfaces;

public interface ITipoFaltaDAC
{
    Task<int> InsertarTipoFalta(TipoFalta tipoFalta);
    Task<bool> ActualizarTipoFalta(TipoFalta tipoFalta);
    Task<List<TipoFalta>> ListaTipoFaltas();
    Task<TipoFalta> obtieneTipoFaltas(int IdTipoFalta);
}
