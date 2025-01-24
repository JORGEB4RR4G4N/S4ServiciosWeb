namespace S4.DAC.DataAcces.Catalogos.Interfaces;

public interface ITipoGolDAC
{
    Task<int> InsertarTipoGol(TipoGol TipodGol);
    Task<bool> ActualizarTipoGol(TipoGol TipodGol);
    Task<List<TipoGol>> ListaTipoGol();
    Task<TipoGol> obtieneTipoGol(int IdTipoGol);
}
