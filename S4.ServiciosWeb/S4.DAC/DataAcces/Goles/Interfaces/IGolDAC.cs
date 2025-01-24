namespace S4.DAC.DataAcces.Goles.Interfaces;

public interface IGolDAC
{
    Task<int> InsertarGol(Gol gol);
    Task<bool> ActualizarGol(Gol gol);
    Task<List<Gol>> ListaGol();
    Task<Gol> ObtieneGol(int IdFalta);
}
