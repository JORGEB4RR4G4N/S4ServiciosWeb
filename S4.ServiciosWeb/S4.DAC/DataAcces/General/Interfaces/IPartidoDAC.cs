namespace S4.DAC.DataAcces.General.Interfaces;

public interface IPartidoDAC
{
    Task<List<PartidoDTO>> ListaPartidos();
    Task<PartidoDTO> ObtienePartido(int IdTorneo);
    Task<int> InsertaPartido(Partido torneo);
    Task<bool> ActualizaPartido(Partido torneo);
}
