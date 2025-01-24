namespace S4.DAC.DataAcces.Cambios.Interfaces;

public interface ICambioDAC
{
    Task<int> InsertarCambio(Cambio cambio);
    Task<bool> ActualizarCambio(Cambio cambio);
    Task<List<CambioDTO>> ListaCambio();
    Task<CambioDTO> ObtenCambio(int IdCambio);
}
