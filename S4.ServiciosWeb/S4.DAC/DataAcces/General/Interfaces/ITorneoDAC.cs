namespace S4.DAC.DataAcces.General.Interfaces;

public interface ITorneoDAC
{
    Task<List<Torneo>> ObtieneTorneos();
    Task<Torneo> ObtieneTorneo(int IdTorneo);
    Task<int> InsertaTorneo(Torneo torneo);
    Task<bool> ActualizaTorneo(Torneo torneo);
}
