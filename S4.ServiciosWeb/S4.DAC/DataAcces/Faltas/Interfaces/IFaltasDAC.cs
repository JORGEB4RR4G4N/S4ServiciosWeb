namespace S4.DAC.DataAcces.Faltas.Interfaces;

public interface IFaltasDAC
{
    Task<int> InsertarFalta(Falta falta);
    Task<bool> ActualizarFalta(Falta falta);
    Task<List<FaltaDTO>> ListaFalta();
    Task<FaltaDTO> ObtieneFalta(int IdFalta);
}
