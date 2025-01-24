namespace S4.DAC.DataAcces.Catalogos.Interfaces;

public interface IOrigenDAC
{
    Task<int> InsertarOrigen(Origen origen);
    Task<bool> ActualizarOrigen(Origen origen);
    Task<List<Origen>> ListaOrigen();
    Task<Origen> ObtenOrigen(int IdOrigen);

}
