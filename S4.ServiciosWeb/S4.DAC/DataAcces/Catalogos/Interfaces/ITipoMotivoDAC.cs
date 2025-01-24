namespace S4.DAC.DataAcces.Catalogos.Interfaces;

public interface ITipoMotivoDAC
{
    Task<int> InsertarTipoMotivo(TipoMotivo TipodGol);
    Task<bool> ActualizarTipoMotivo(TipoMotivo TipodGol);
    Task<List<TipoMotivo>> ListaTipoMotivo();
    Task<TipoMotivo> obtieneTipoMotivo(int IdTipoGol);

}
